namespace gta_natives
{
  public class ApiEntity
  {
    public string classify { get; set; } = string.Empty;
    public string name { get; set; } = string.Empty;
    public string source_code { get; set; } = string.Empty;
    public string return_value { get; set; } = string.Empty;
    public List<ParameterEntity> parameters { get; set; } = new List<ParameterEntity>();
  }
}
