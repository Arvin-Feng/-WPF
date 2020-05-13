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
