// See https://aka.ms/new-console-template for more information

using DelegateReflection;

var var = new MyVariable<int>();

var fields = var.GetType().GetFields();
var field = fields.First(e => e.Name == "OnChangedHandlers");
var handler = new Handler(); 

// var prevObj = field.GetValue(var);
var.OnChangedHandlers += handler.OnChangeHandler;
// var newObj = field.GetValue(var);
// var.OnChangedHandlers += handler.OnChangeHandler;
// var newNewObj = field.GetValue(var);

var method = handler.GetType().GetMethod("OnChangeHandler");
Delegate del = Delegate.CreateDelegate(field.FieldType, handler, method);
// var del2 = Delegate.Combine(del, del);

var originDel = (Delegate)field.GetValue(var);
var del2 = Delegate.Combine(originDel, del);
field.SetValue(var, del2);

var.Value = 5;

Console.WriteLine(var.Value);
Console.WriteLine("Hello, World!");

class Handler
{
    public void OnChangeHandler(int prev, int @new)
    {
        Console.WriteLine(prev);
        Console.WriteLine(@new);
    }
}