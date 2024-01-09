// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

var sopa = new List<string>();
int longitud = 64;

for (int i = 0; i < 64; i++)
{
    string palabra = WordFinder.GenerarStringAleatorio(longitud);
    sopa.Add(palabra);
}

sopa[3] = "coldxiidkzmwenagcoxrtwkmrnuomikoddxcfnnhkikruvpmeijndywmtcmnqwkf";
sopa[4] = "cdldxiidkzmwenagcoxrtwkmrnuomikoddxcfnnhkikruvpmeijndywmtcmndniw";


IEnumerable<string> wordstream = new List<string>
{
    "cold",
    "wind",
    "snow",
    "chill",
};

WordFinder wF = new WordFinder(sopa);
var resultado = wF.Find(wordstream);
if (resultado != null)
{
    Console.WriteLine("Palabras encontradas: \n");
    foreach (var item in resultado)
    {
        Console.WriteLine(item);
    }
}
