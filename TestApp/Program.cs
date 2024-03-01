// See https://aka.ms/new-console-template for more information
using AuctionApp.Service.Core;
string xa = "'ERROR: FDFDSFSD'";
string test = $"fdfsdfsd {xa}, fsdfsdf";

var index = test.IndexOf("ERROR");
var index1 = test.IndexOf(",", index);

var test1 = test.Substring(index, index1 - index - 1);

Console.WriteLine(test1);

Console.ReadLine();