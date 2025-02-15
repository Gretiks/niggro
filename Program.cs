using System;
using System.Collections.Generic;
using System.Numerics;


namespace ConsoleApp1 {
    class Program {

        static void Wypisz(List<Los> ticket) {
            for (int i = 0; i < ticket.Count; i++) {
                Console.Write(i+1 + ": ");
                ticket[i].toString();
                Console.WriteLine();
            }
        }

        static Los Stawianie() {
            String s;
            Los L = new Los();
            int liczba;
            List<int> wybraneLiczby = new List<int>();
            
            Console.Clear();
            
            for (int i = 0; i < 6; i++) {
                try {
                    Console.Write((i+1) + ": ");
                    s = Console.ReadLine();
                    liczba = int.Parse(s);

                    if (liczba > 0 && liczba < 50 && !wybraneLiczby.Contains(liczba)) 
                        wybraneLiczby.Add(liczba);
                    else
                        i--;
                    
                    Console.Clear();
                }
                catch (Exception e) {
                    Console.Clear();
                    Console.WriteLine("Podaj liczbe");
                    i--;
                }
            }


            if (wybraneLiczby.Count == 6) {
                wybraneLiczby.Sort();
                L = new Los(wybraneLiczby);
            }


            return L;
        }
        
        static Random random = new Random();
        static int kumulacja;
        static void Main(string[] args) {
            List<Los> ticket = new List<Los>();
            long pieniadze = 30;
            kumulacja = random.Next(2, 45) * 1000000;
            int dzien = 1;
            char wybor;

            do {
                Console.WriteLine("Witaj w losowaniu");
                Console.WriteLine("Dzien {0}, obecne pieniadze {1}", dzien, pieniadze);
                Console.WriteLine("\nObecna kumulacja {0}\n", kumulacja);
                Console.WriteLine("Postawione kupony");

                if (ticket.Count != 0)
                    Wypisz(ticket);
                
                Console.WriteLine();
                
                Console.WriteLine("Menu");
                Console.WriteLine("1. Postaw kupon");
                Console.WriteLine("2. Losowanie");
                Console.WriteLine("3. Koniec");

                do {
                    wybor = Console.ReadKey().KeyChar;
                } while (wybor != '1' && wybor != '2' && wybor != '3');
                
                Console.Write(wybor);

                switch (wybor) {
                    case '1':
                        if (pieniadze < 3) {
                            Console.WriteLine("Nie stac cie biedaku");
                            break;
                        }
                        ticket.Add(Stawianie());
                        pieniadze -= 3;
                        Console.Clear();
                        break;
                    
                    case '2':
                        List<int> wylosowane_liczby = new List<int>();
                        int liczba;

                        for (int i = 0; i < 6; i++) {
                            do {
                                liczba = random.Next(1, 50);
                            }while(wylosowane_liczby.Contains(liczba));
                            wylosowane_liczby.Add(liczba);
                        }
                        wylosowane_liczby.Sort();
                        
                        
                        Console.Clear();
                        Console.WriteLine("Wylosowane liczby: ");
                        foreach(int x in wylosowane_liczby)
                            Console.Write(x + ", ");
                        
                        Console.WriteLine("\nPostawione kupony");
                        Wypisz(ticket);
                        
                        if (!ticket.Any()) {
                            kumulacja = random.Next(2, 45) * 1000000;
                            dzien++;
                            break;
                        } else {
                            List<int> trafione_liczby = new List<int>();
                            List<int> los;

                            Console.WriteLine("Trafione liczby: ");
                            for (int i = 0; i < ticket.Count(); i++) {
                                los = ticket[i].getList();
                                foreach (int x in los) {
                                    if(wylosowane_liczby.Contains(x))
                                        trafione_liczby.Add(x);
                                }
                                trafione_liczby.Sort();

                                
                                Console.Write("kupon {0}: ", i+1);
                                foreach(int x in trafione_liczby)
                                    Console.Write(x + ", ");
                                
                                
                                Console.WriteLine();
                                if (trafione_liczby.Count() == 3) pieniadze += 21;
                                else if(trafione_liczby.Count() == 4) pieniadze += 170;
                                else if(trafione_liczby.Count() == 5) pieniadze += 5000;
                                else if(trafione_liczby.Count() == 6) pieniadze += kumulacja;
                                trafione_liczby.Clear();
                            }


                            Console.ReadKey();
                            
                            kumulacja = random.Next(2, 45) * 1000000;
                            dzien++;
                            ticket.Clear();
                            break;
                        }
                    
                    case '3':
                        Console.Clear();
                        Console.WriteLine("Udalo ci sie zarobic pieniadze {0}", pieniadze-30);
                        return;
                        
                        
                }
                
                Console.Clear();

                
            } while (true);
            
        }
    }
}




