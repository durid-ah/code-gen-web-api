namespace code_gen_web_api;

 public class SomeTestMethods
 {
    public string NoParamReturnVal()
    {
        return "NoParamReturnVal";
    }

    public string ParamReturnVal(string value)
    {
        return $"ParamReturnVal {value}";
    }
}
