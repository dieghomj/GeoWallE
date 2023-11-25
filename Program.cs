while (true)
{
    Console.Write("> ");
    var line = Console.ReadLine();
    
    if (string.IsNullOrWhiteSpace(line)) return;
    
    foreach(var t in new Lexer(line))
        System.Console.WriteLine(t);
}
    