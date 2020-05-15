# 深入浅出WPF

------

最近由于工作需要再次读完了刘铁猛老师的《深入浅出WPF》,在书中学习到了很多基础知识，每个知识点自己都亲手写了Sample，加深对基础知识的掌握，好记性不如烂笔头，把学习笔记和Sample都整理到github上，作为自己一份知识积累。

借用书里的一句话：**万丈高楼平地起，勿在浮沙筑高台**

## 一、xaml的Attribute与对象的Property映射
1. Attribute = Value，因为Value是字符串类型，一些简单的类型转化系统已经帮我们完成了，比如字符串转化数值类型，但一些复杂类型就需要我们自己处理了，比如Property是个对象。
2. 对于赋值复杂类型可以使用TypeConverter就行处理。
3. 参考代码：3.2.1使用Attribute给对象赋值。

## 二、 为属性对象赋值的方法：（3.2.1使用Attribute给对象赋值）
1. 使用xaml的Attribute初始化随性属性（Property）。
2. CS后台代码设置。
3. 使用属性元素初始化对象属性。

## 三、x命名空间： 都和解析XAML语言相关，也可以称为“XAML命名空间”
1. x:Class - 告诉编译器XAML编译结果与指定的后台CS代码合并， 起到关键作用的关键字是：partial 。
2. x:ClassModifier - 设置访问级别，Public、Private、Internal 。

## 四、控件与布局
   ### 几个常用基类：
   1. ContentControl
   2. HeaderedContentControl
   3. ItemsControl
   4. HeaderedItemsControl
   5. Decorator
   6. TextBox TextBlock
   
   WPF布局理念就是把一个布局元素作为ContentControl或者HeaderedContentControl控件的Content, 再在布局元素里面添加要布局的子级控件、
   
## 五、Binding
1. 模型
  1). 目标《=== （校验器）Binding（转换器） ===》源
  2). Binding的源一般是逻辑层对象，但有时候为了让界面产生联动效果，源也可以是目标UI控件；
2. BindingOperations.SetBinding() 把数据源和目标连接在一起，三个参数声明：
		第一个参数：指定绑定的目标；
		第二个参数：指定数据传达到哪个属性，这里面是一个静态的依赖属性；
		第三个参数：指定Binding实例；
3. INotifyPropertyChanged 显示此接口
		1). 数据驱动界面： Binding是一种自动机制，当值变化后属性要有能力通知Binding， 让Binding把变化传递给UI元素。
		2). 如果想让作为Binding源的对象具有自动通知Binding自己的属性值已经变化的能力，需要让类实现INotifyPropertyChanged接口，
		   并在属性的set语句中激发PropertyChanged事件；
4. 事件监听
		1. 把NotifiOnSourceUpdated、NotifiOnTargetUpdated属性值数值为true，则当源或者目标被更新后，
		   会激发相应的SourceUpdated事件和TargetUpdated事件。 
         
## 六、为Binding指定Source的几种方法：
**1. 普通CLR类型对象**
  - 实现了INotifyPropertyChanged接口的普通CLR类型对象，可通过设置PropertyChanged事件来通知Binding数据已经被更新。

**2. 普通CLR普通集合类型对象**
  - 包括数值、List<T>、ObservableCollection<T>等集合对象。  
  - 比如ListBox的ItemsSource就可以是一个list对象，Items内容格式由数据外衣DataTemplate控制， 如果没有显示的设置控件的DataTemplate，系统会默认给有最简单的DataTemplate， 数据外衣DataTemplate决定了数据外观，非常重要。 
  - 例子：6.3.7数据源之List。
  - （重要）在使用集合类型对象作为控件的ItemsSource是一般会使用 ObservableCollection<T>代替Lits<T>,因为ObservableCollection<T>实现了INotifyCollectionChanged和INotifyPropertyChanged接口，数据发生变化会立即显示在界面上。

**3. ADO.NET数据对象对象(demo: 6.3.8数据源之ADO.NET)**
  - WPF支持列表控件Binding到DataTable， 具体是使用DataTable的DefaultView属性进行绑定；
  - 但是列表控件一般都是也泛型进行绑定， 更加灵活。

**4. XML作为数据源**
  - 当使用XML作为Binding的Source时，使用XPath属性，而不是Path;
  - 使用@符号表示的是XML元素的Attribute,不加@符号的字符串表示的是子级元素;
  - HierarchicalDataTemplate是个很重要的类，HierarchicalDataTemplate顾名思义，分层数据模板，就是用来定义分层数据样式的模板，一般多用于MenuItem和TreeViewItem 。

**5. 依赖对象（Depandency）**
  - 依赖对象不仅可以作为Binding的目标，同时也可以作为Binding的源，依赖对象中的依赖属性可以作为Binding的Path 。

**6. DataContent** 
  - 当多个对象都使用Binding关注一个对象时；
  - 当Source对象不能被直接访问时；
  - 只有Binding属性，不直接指明Source时，会在树里找具有指定属性的DataContent数据对象；
  - WPF每一个节点都对应一个对象， 每个对象几乎都含有DataContent属性；

**7. 通用ElementName指定**

**8. ObjectDataProvider(demo: 6.3.11.1ObjectDataProvider、6.3.11.2ObjectDataProvider)**
  - 使用ObjectDataProvider包装类的方法，作为Binding的Source。
  - 数据驱动UI的原要求尽量地使用数据对象作为Binding的Source，而把UI元素当做Binding的Target。

**9. 通过RelativeSource相对的指定 （demo：6.3.12RelativeSource）**
  - 当一个Binding有明确数据源时我们可以通过给Source或者ElementName赋值关联，当我们不确定Source名字叫什么时，使用RelativeSource。

**10.使用LINQ查询到数据 （6.3.10使用LINQ结果作为Binding的源）**
  - LINQ的查询结果是一个IEnumberable<T>的对象，可以作为ItemsSouce来使用。
  - 使用LINQ从List、DataTabe、xml里获取IEnumberable<T>的对象。
	
## 七、Binding数据的校验与转换（数据校验：ValidationRulues	数据转换：Coverter）
**1. 数据校验：ValidationRule**

**2. 数据转换：IValueConverter**
  - 当Source端Path所关联的数据与Target端目前属性的数据类型不一致时，可以添加数据转换器。
  -  简单的数据转换系统可以自动完成，比如 字符串到数值，  但是复杂的就需要添加DataConverter了，就是现实IValueConverter接口。
  
## 八、多路绑定 MultiBinding
  - UI上需要显示的信息有不止一个数据来决定，比如当多个条件都满足时。
  - 凡是能使用Binding的场合，都能使用MultiBinding。
  - MultiBinding有一个重要的Bindings属性， 用来把一组Binding组合起来， Bindings.add顺序是敏感的。
  - MultiBinding的Converter显示的是IMultiValueConverter接口。
  - 注意学习这段lamda表达式写法：
  ```C#
	if (!values.Cast<string>().Any(text=>string.IsNullOrEmpty(text)) 
                && values[0].ToString() == values[1].ToString()
                && values[2].ToString() == values[3].ToString())
        {
                return true;
         }
        return false;
```
**Binding小结**
  -  WPF的核心理念是数据驱动UI，支撑这个理念的基础是Data Binding和与之相关的数据校验与转化！
  - 使用Binding时，最重要的事情就是准确地设置它的Source(源)和Path(路径)。
  
 ## 十、依赖属性: （DependencyObjcet与DependencyProperty是WPF属性系统的核心）
   1. 依赖属性就是一种自己可以没有值，并能通过使用Binding从数据源获取值的属性。
   2. 拥有依赖的对象就是“依赖对象”。
   3. WPF中，必须使用依赖对象作为依赖属性的宿主，使二者结合起来，才能形成完整的Binding目标被数据所驱动。
   4. WPF中，依赖对象被DependencyObjcet类实现，依赖对象则由DependencyProperty实现。
     - DependencyObject具有GetValue和SetValue两个方法。
     - 这两个方法都以DependencyProperty对象为属性。
   5. 快速生成依赖属性模板的快捷键： propdp
   
  ## 十一、附加属性
  1. 对象在特定环境下被动态赋予的属性。  （本来没这个属性， 放在一个特定的环境中， 才具有的属性）
  2. 附加属性的本质是依赖属性。
  3. 声明附加属性快捷键：propa
  
 ## 十二、事件
   **1. 标准CLR事件: 订阅、发布、关联， 不详细写了， Winform里都是这种事件。**
   
   **2. 路由事件： WPF的特有事件机制； （demo： 8.3.1使用WPF内置路由事件）**
   - WPF的事件系统和属性系统类似，使用【静态字段 -> CLR包装器】策略。
   - 事件的发布者并不关心谁来处理这个时间， 知识发出时间就不管了。
   - 事件从当前发布者开始，一层一层沿着树上次传递，树上的每个节点（也就是对象）都可以定义事件监听器来处理时间。
   
   **3. 自定义路由事件，步骤**
   - 声明并注册路由事件。
   - 为路由事件添加CLR事件包装。
   - 创建可以激发路由事件的方法。
   
  ## 十三、命令
  1. 特点： 一处定义、处处使用
  2.  命令系统的基本元素 （演示以下流程的demo：9.1.3.1命令）
    2.1 命令（Command）
      - 实现ICommand接口，平时使用最多的是RoutedCommand类， 也可以自定义。
    2.2 命令源（CommandSource）
      - 命令的发送者， 实现了ICommandSource接口的类，很多界面元素都实现的此接口， 比如 Button、ListBoxItem等。
    2.3 命令目标（CommandTarget）
      - 命令发生给谁，命令目标必须是实现了IInputElement接口的类。
    2.4 命令关联（Command Binding）
      - 关联命令，执行命令之前判断命令是否可执行、命令执行之后处理一些后续工作。
  3. WPF命令库
    - 系统也预定义了一些命令， 如Open、Save等这些就不需要自己定义了， 拿来直接用，他们都来源于ApplicationCommands类的静态属性。
  4. 命令参数 (9.2.2.1自定义Command)
    4.1 CommandPrameter
      - 很多命令都是一些类的静态属性（比如 ApplicationCommands），实例永远只有一个， 要想区分不同的命令源，需要使用参数。
      - 命令源实现了ICommandSource接口， 而此接口有个属性就是CommandPrameter。
  5. 控件的Command属性就一个，命令有很多， 使用Binding可以改变Command对应的不同命令。
