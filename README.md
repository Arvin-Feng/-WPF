# 深入浅出WPF

------

最近由于工作需要再次读完了刘铁猛老师的《深入浅出WPF》,在书中学习到了很多基础知识，每个知识点自己都亲手写了Sample，加深对基础知识的掌握，好记性不如烂笔头，把学习笔记和Sample都资料到Github上，作为自己一份知识积累。

借用刘大师的一句话：**勿在浮沙筑高台**

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
