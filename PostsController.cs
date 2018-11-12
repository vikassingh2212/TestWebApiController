public HttpResponseMessage Get()
{
    var json = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/posts.json"));
    return new HttpResponseMessage()
    {
        Content = new StringContent(json, Encoding.UTF8, "application/json"),
        StatusCode = HttpStatusCode.OK
    };
}

public HttpResponseMessage Get(int startIndex, int endIndex)
{
    var json = File.ReadAllText(System.Web.HttpContext.Current.Server.MapPath(@"~/App_Data/posts.json"));


    JArray array = JArray.Parse(json);
    JArray result = new JArray(array.Where(item => item.Children<JToken>().Any(p => ((JProperty)p).Name == "id" && (int)((JProperty)p).Value >= startIndex && (int)((JProperty)p).Value <= endIndex)).ToList());

    return new HttpResponseMessage()
    {
        Content = new StringContent(result.ToString(), Encoding.UTF8, "application/json"),
        StatusCode = HttpStatusCode.OK
    };
}
