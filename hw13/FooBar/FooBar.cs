namespace FooBar;

public class FooBar {

    private readonly int _n;

    public FooBar(int n) {
        _n = n;
    }

    public void Foo(Action printFoo) {
        for (var i = 0; i < _n; i++) {
            // printFoo() outputs "foo". Do not change or remove this line.
            printFoo();
        }
    }
    
    public void Bar(Action printBar) {
        for (var i = 0; i < _n; i++) {
            // printBar() outputs "bar". Do not change or remove this line.
            printBar();
        }
    }
}
