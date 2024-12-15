using DLinkedList;

// This is a simple doubly linked list implementation and the main program to play around with it.
var list = new DLinkedList<int>();

list.AppendEnd(10);
list.AppendEnd(20);
list.AppendEnd(20);
list.AppendEnd(30);

Console.WriteLine("Printing Forward:");
list.PrintForward();

Console.WriteLine("Printing Backwards and Forwards:");
list.PrintBackward(); // Sollte 30 20 10 ausgeben
list.PrintForward(); // Sollte 10 20 30 ausgeben

list.AppendStart(10);
list.AppendStart(100);

Console.WriteLine("Printing Backwards and Forwards after adding 10 and 100:");
list.PrintBackward(); // Sollte 30 20 10 10 100 ausgeben
list.PrintForward(); // Sollte 100 10 10 20 30 ausgeben

Console.WriteLine("Delete 20...");

list.Delete(20);
Console.WriteLine("Print it Backwards and Forwards after deletation:");

list.PrintBackward(); // Sollte 30 10 ausgeben
list.PrintForward(); // Sollte 10 30 ausgeben
