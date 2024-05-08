using gta_natives;
using System.Text;

string path = "D:\\P6060369\\other\\natives-master";
List<string> mdFiles = Directory.GetFiles(path, "*.md", SearchOption.AllDirectories).ToList();

List<string> excludeFields = new List<string>()
{ 
  "---"
};

StreamReader srMdFile;
string readLine = string.Empty;
string[] stringSplit;

StringBuilder sbSourceCodeBlock = new StringBuilder();
StringBuilder sbReturnValueBlock = new StringBuilder();

bool isSourceCodeBlock = false;
bool isReturnValueBlock = false;
bool isParametersBlock = false;

List<ParameterEntity> parameters = new List<ParameterEntity>();

List<ApiEntity> apis = new List<ApiEntity>();
ApiEntity apiEntity;

string title = string.Empty;

foreach (string md in mdFiles)
{
  srMdFile = new StreamReader(md, Encoding.UTF8);
  while (!srMdFile.EndOfStream)
  {
    readLine = srMdFile.ReadLine()!;

    if (readLine == string.Empty)
    {
      continue;
    }
    else if (excludeFields.Contains(readLine))
    {
      continue;
    }

    apiEntity = new ApiEntity();

    if (readLine.StartsWith("ns"))
    {
      stringSplit = readLine.Split(':');
      if (stringSplit.Length == 2)
      {
        apiEntity.classify = stringSplit[1].Trim();
      }
    }
    else if (readLine.StartsWith("## "))
    {
      isReturnValueBlock = false;
      isParametersBlock = false;

      title = readLine.Substring(3, readLine.Length - 3);
      switch (title)
      {
        case "Return value":
          isReturnValueBlock = true;
          break;
        case "Parameters":
          isParametersBlock = true;
          break;
        default:
          apiEntity.name = title;
          break;
      }
    }
    else if (readLine.StartsWith("```"))
    {
      if (!isSourceCodeBlock)
      {
        isSourceCodeBlock = true;
      }
      else
      {
        apiEntity.source_code = sbSourceCodeBlock.ToString();
        sbSourceCodeBlock = new StringBuilder();
        isSourceCodeBlock = false;
      }
    }
    else if (readLine.StartsWith("* **"))
    {
      if (isParametersBlock)
      {
        stringSplit = readLine.Split(":");

        if (stringSplit.Length == 2)
        {
          parameters.Add(new ParameterEntity()
          {
            name = stringSplit[0].Replace("*", "").Trim(),
            value = stringSplit[1].Trim()
          });
        }
      }
    }
    else
    {
      if (isSourceCodeBlock)
      {
        sbSourceCodeBlock.AppendLine(readLine);
      }

      if (isReturnValueBlock)
      {
        sbReturnValueBlock.AppendLine(readLine);
      }
    }
  }
}