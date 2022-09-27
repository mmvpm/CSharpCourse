using Interfaces;

var myClass = new MyClass();
myClass.PrintName();                // => MyClass
((Interface1) myClass).PrintName(); // => Interface1
((Interface2) myClass).PrintName(); // => Interface2
