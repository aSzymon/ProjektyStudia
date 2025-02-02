using System;
using System.Threading;

namespace Statki {
    internal class Program {

        static void wstep() {

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.Write($"\nGRA W STATKI\n\n");

            Console.WriteLine($"Witaj w grze statki. \nGra polega na próbie zestrzelenia wrogiego statku z każdej drużyny na przemian.\nLecz najpierw musisz wybrać miejsce dla twoich statków oraz wybrać swoj nick, twój przeciwnik musi zrobić to samo.\n\nMasz do dyspozycji statki :\n- 4 statki jednomasztowe\n- 3 statki dwumasztowe\n- 2 statki trzymasztowe\n- 1 statek czteromasztowy\n\nPowodzenia !");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;

            Console.WriteLine($"\nNaciśnij dowolny klawisz aby rozpocząć grę");
            Console.ReadKey();
            Console.WriteLine("Ładowanie...");
            Thread.Sleep(3000);
            Console.Clear();

            Console.ResetColor();

        }

        static void wyswietlPlansze(int[,] plansza) {

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int wiersz = 0; wiersz < plansza.GetLength(0); wiersz++) {

                Console.Write($"{wiersz} | ");

                for (int kolumna = 0; kolumna < plansza.GetLength(1); kolumna++) {

                    if (plansza[wiersz, kolumna] == 0) {

                        Console.Write("_ ");

                    } else if (plansza[wiersz, kolumna] == 1) {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("1 ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    } else if (plansza[wiersz, kolumna] == 2) {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("2 ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    } else if (plansza[wiersz, kolumna] == 3) {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("3 ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    } else if (plansza[wiersz, kolumna] == 4) {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("4 ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.ResetColor();
        }

        static void ustawStatekJednomasztowy(int[,] plansza) {

            bool ustawiono = false;

            while (!ustawiono) {

                Console.WriteLine("Podaj pierwszą współrzędną (0-9): ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string wierszString = Console.ReadLine();
                Console.ResetColor();

                Console.WriteLine("Podaj drugą współrzędną (0-9): ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string kolumnaString = Console.ReadLine();
                Console.ResetColor();

                if (wierszString.Equals("") || kolumnaString.Equals("")) {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Współrzędna nie może być pusta\n\n");
                    Console.ResetColor();

                } else {
                  
                    int wiersz = int.Parse(wierszString);
                    int kolumna = int.Parse(kolumnaString);

                    Console.WriteLine();

                    if (wiersz >= 0 && wiersz < plansza.GetLength(0) && kolumna >= 0 && kolumna < plansza.GetLength(1)) {

                        if ((kolumna < plansza.GetLength(1) - 1 && plansza[wiersz, kolumna + 1] != 0) ||
                            (kolumna > 0 && plansza[wiersz, kolumna - 1] != 0) ||
                            (wiersz < plansza.GetLength(0) - 1 && plansza[wiersz + 1, kolumna] != 0) ||
                            (wiersz > 0 && plansza[wiersz - 1, kolumna] != 0)) {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                            Console.ResetColor();

                        } else {

                            if (plansza[wiersz, kolumna] == 0) {

                                plansza[wiersz, kolumna] = 1;
                                ustawiono = true;

                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine($"\nStatek ustawiony!\n");
                                Console.ResetColor();

                            } else {

                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("\nTo pole jest już zajęte! Wybierz inne.\n");
                                Console.ResetColor();
                            }
                        }

                    } else {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNieprawidłowe współrzędne. Spróbuj ponownie.\n");
                        Console.ResetColor();
                    }
                }

            }
        }

        static void ustawStatekDwumasztowy(int[,] plansza) {

            int iloscCzesciStatku = 1;

            int wierszTymczasowy = -1;
            int kolumnaTymczasowa = -1;

            while (iloscCzesciStatku <= 2) {

                Console.WriteLine("Podaj pierwszą współrzędną (0-9): ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string wierszString = Console.ReadLine();
                Console.ResetColor();

                Console.WriteLine();

                Console.WriteLine("Podaj drugą współrzędną (0-9): ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string kolumnaString = Console.ReadLine();
                Console.ResetColor();

                if (wierszString.Equals("") || kolumnaString.Equals("")) {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Współrzędna nie może być pusta.\n\n");
                    Console.ResetColor();

                } else {

                    int wiersz = int.Parse(wierszString);
                    int kolumna = int.Parse(kolumnaString);

                    Console.WriteLine();

                    if (wiersz >= 0 && wiersz < plansza.GetLength(0) && kolumna >= 0 && kolumna < plansza.GetLength(1)) {

                        if (plansza[wiersz, kolumna] == 0) {

                            if (iloscCzesciStatku == 1) {

                                if ((kolumna < plansza.GetLength(1) - 1 && plansza[wiersz, kolumna + 1] != 0) ||
                                    (kolumna > 0 && plansza[wiersz, kolumna - 1] != 0) ||
                                    (wiersz < plansza.GetLength(0) - 1 && plansza[wiersz + 1, kolumna] != 0) ||
                                    (wiersz > 0 && plansza[wiersz - 1, kolumna] != 0)) {

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                    Console.ResetColor();

                                } else {

                                    plansza[wiersz, kolumna] = 2;

                                    wierszTymczasowy = wiersz;
                                    kolumnaTymczasowa = kolumna;

                                    iloscCzesciStatku++;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"Część statku ustawiona!\n");
                                    Console.ResetColor();

                                }

                            } else if (iloscCzesciStatku == 2) {

                                if ((wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa + 1)) ||
                                   (wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa - 1)) ||
                                   ((wiersz == wierszTymczasowy + 1) && kolumna == kolumnaTymczasowa) ||
                                   ((wiersz == wierszTymczasowy - 1) && kolumna == kolumnaTymczasowa)) {

                                    if (wiersz == 9 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 2;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 2;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 2;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 2;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz, kolumna + 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 2;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz + 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 2;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz - 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 2;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz, kolumna - 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 2;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 2 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0))) {

                                        plansza[wiersz, kolumna] = 2;

                                        iloscCzesciStatku++;

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Statek ustawiony!\n");
                                        Console.ResetColor();

                                    } else {

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                        Console.ResetColor();

                                    }

                                } else {

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"Części statków muszą być obok siebie.\n");
                                    Console.ResetColor();

                                }

                            }

                        } else {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("To pole jest już zajęte! Wybierz inne.\n");
                            Console.ResetColor();

                        }


                    } else {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nieprawidłowe współrzędne. Spróbuj ponownie.\n");
                        Console.ResetColor();

                    }

                    wyswietlPlansze(plansza);

                }
            }

        }

        static void ustawStatekTrzymasztowy(int[,] plansza) {

            int iloscCzesciStatku = 1;

            int wierszTymczasowy = -1;
            int kolumnaTymczasowa = -1;

            while (iloscCzesciStatku <= 3) {

                Console.WriteLine("Podaj pierwszą współrzędną (0-9): ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string wierszString = Console.ReadLine();
                Console.ResetColor();

                Console.WriteLine();

                Console.WriteLine("Podaj drugą współrzędną (0-9): ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string kolumnaString = Console.ReadLine();
                Console.ResetColor();

                if (wierszString.Equals("") || kolumnaString.Equals("")) {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Współrzędna nie może być pusta.\n\n");
                    Console.ResetColor();

                } else {

                    int wiersz = int.Parse(wierszString);
                    int kolumna = int.Parse(kolumnaString);

                    Console.WriteLine();

                    if (wiersz >= 0 && wiersz < plansza.GetLength(0) && kolumna >= 0 && kolumna < plansza.GetLength(1)) {

                        if (plansza[wiersz, kolumna] == 0) {

                            if (iloscCzesciStatku == 1) {

                                if ((kolumna < plansza.GetLength(1) - 1 && plansza[wiersz, kolumna + 1] != 0) ||
                                (kolumna > 0 && plansza[wiersz, kolumna - 1] != 0) ||
                                (wiersz < plansza.GetLength(0) - 1 && plansza[wiersz + 1, kolumna] != 0) ||
                                (wiersz > 0 && plansza[wiersz - 1, kolumna] != 0)) {

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                    Console.ResetColor();

                                } else {

                                    plansza[wiersz, kolumna] = 3;

                                    wierszTymczasowy = wiersz;
                                    kolumnaTymczasowa = kolumna;

                                    iloscCzesciStatku++;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"Część statku ustawiona!\n");
                                    Console.ResetColor();

                                }

                            } else if (iloscCzesciStatku == 2) {

                                if ((wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa + 1)) ||
                                    (wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa - 1)) ||
                                    ((wiersz == wierszTymczasowy + 1) && kolumna == kolumnaTymczasowa) ||
                                    ((wiersz == wierszTymczasowy - 1) && kolumna == kolumnaTymczasowa)) {

                                    if (wiersz == 9 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna + 1] == 0 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna - 1] == 0 && plansza[wiersz + 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz - 1, kolumna] == 0 && plansza[wiersz, kolumna + 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz + 1, kolumna] == 0 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz - 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna - 1] == 0 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna + 1] == 0 && plansza[wiersz - 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0))) {

                                        plansza[wiersz, kolumna] = 3;

                                        wierszTymczasowy = wiersz;
                                        kolumnaTymczasowa = kolumna;

                                        iloscCzesciStatku++;

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Część statku ustawiona!\n");
                                        Console.ResetColor();

                                    } else {

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                        Console.ResetColor();

                                    }


                                } else {

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"Części statków muszą być obok siebie\n");
                                    Console.ResetColor();

                                }

                            } else if (iloscCzesciStatku == 3) {

                                if ((wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa + 1)) ||
                                    (wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa - 1)) ||
                                    ((wiersz == wierszTymczasowy + 1) && kolumna == kolumnaTymczasowa) ||
                                    ((wiersz == wierszTymczasowy - 1) && kolumna == kolumnaTymczasowa)) {

                                    if (wiersz == 9 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna + 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz + 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz - 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna - 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 3;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 3 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0))) {

                                        plansza[wiersz, kolumna] = 3;
 
                                        iloscCzesciStatku++;

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"statek ustawiony!\n");
                                        Console.ResetColor();

                                    } else {

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                        Console.ResetColor();

                                    }


                                } else {

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"Części statków muszą być obok siebie.\n");
                                    Console.ResetColor();

                                }

                            }

                        } else {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("To pole jest już zajęte! Wybierz inne.\n");
                            Console.ResetColor();

                        }

                    } else {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nieprawidłowe współrzędne. Spróbuj ponownie.\n");
                        Console.ResetColor();

                    }

                    wyswietlPlansze(plansza);

                }
            }

        }

        static void ustawStatekCzteromasztowy(int[,] plansza) {

            int iloscCzesciStatku = 1;

            int wierszTymczasowy = -1;
            int kolumnaTymczasowa = -1;

            while (iloscCzesciStatku <= 4) {

                Console.WriteLine("Podaj pierwszą współrzędną (0-9): ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string wierszString = Console.ReadLine();
                Console.ResetColor();

                Console.WriteLine();

                Console.WriteLine("Podaj drugą współrzędną (0-9): ");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                string kolumnaString = Console.ReadLine();
                Console.ResetColor();

                if (wierszString.Equals("") || kolumnaString.Equals("")) {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write($"Współrzędna nie może być pusta.\n\n");
                    Console.ResetColor();

                } else {

                    int wiersz = int.Parse(wierszString);
                    int kolumna = int.Parse(kolumnaString);

                    Console.WriteLine();

                    if (wiersz >= 0 && wiersz < plansza.GetLength(0) && kolumna >= 0 && kolumna < plansza.GetLength(1)) {

                        if (plansza[wiersz, kolumna] == 0) {

                            if (iloscCzesciStatku == 1) {

                                if ((kolumna < plansza.GetLength(1) - 1 && plansza[wiersz, kolumna + 1] != 0) ||
                                    (kolumna > 0 && plansza[wiersz, kolumna - 1] != 0) ||
                                    (wiersz < plansza.GetLength(0) - 1 && plansza[wiersz + 1, kolumna] != 0) ||
                                    (wiersz > 0 && plansza[wiersz - 1, kolumna] != 0)) {

                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                    Console.ResetColor();

                                } else {

                                    plansza[wiersz, kolumna] = 4;

                                    wierszTymczasowy = wiersz;
                                    kolumnaTymczasowa = kolumna;

                                    iloscCzesciStatku++;

                                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                                    Console.WriteLine($"Część statku ustawiona!\n");
                                    Console.ResetColor();

                                }

                            } else if (iloscCzesciStatku == 2) {

                                if ((wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa + 1)) ||
                                    (wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa - 1)) ||
                                    ((wiersz == wierszTymczasowy + 1) && kolumna == kolumnaTymczasowa) ||
                                    ((wiersz == wierszTymczasowy - 1) && kolumna == kolumnaTymczasowa)) {

                                    if (wiersz == 9 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0 && plansza[wiersz, kolumna + 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0 && plansza[wiersz, kolumna - 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0 && plansza[wiersz - 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0))) {

                                        plansza[wiersz, kolumna] = 4;

                                        wierszTymczasowy = wiersz;
                                        kolumnaTymczasowa = kolumna;

                                        iloscCzesciStatku++;

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Część statku ustawiona!\n");
                                        Console.ResetColor();

                                    } else {

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                        Console.ResetColor();

                                    }

                                } else {

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"Części statków muszą być obok siebie.\n");
                                    Console.ResetColor();

                                }

                            } else if (iloscCzesciStatku == 3) {

                                if ((wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa + 1)) ||
                                    (wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa - 1)) ||
                                    ((wiersz == wierszTymczasowy + 1) && kolumna == kolumnaTymczasowa) ||
                                    ((wiersz == wierszTymczasowy - 1) && kolumna == kolumnaTymczasowa)) {

                                    if (wiersz == 9 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0 && plansza[wiersz + 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0 && plansza[wiersz, kolumna + 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0 && plansza[wiersz, kolumna - 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0 && plansza[wiersz - 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Część statku ustawiona!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0))) {

                                        plansza[wiersz, kolumna] = 4;

                                        wierszTymczasowy = wiersz;
                                        kolumnaTymczasowa = kolumna;

                                        iloscCzesciStatku++;

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Część statku ustawiona!\n");
                                        Console.ResetColor();

                                    } else {

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                        Console.ResetColor();

                                    }

                                } else {

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"Części statków muszą być obok siebie.\n");
                                    Console.ResetColor();

                                }

                            } else if (iloscCzesciStatku == 4) {

                                if ((wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa + 1)) ||
                                    (wiersz == wierszTymczasowy && (kolumna == kolumnaTymczasowa - 1)) ||
                                    ((wiersz == wierszTymczasowy + 1) && kolumna == kolumnaTymczasowa) ||
                                    ((wiersz == wierszTymczasowy - 1) && kolumna == kolumnaTymczasowa)) {

                                    if (wiersz == 9 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0 && kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            wierszTymczasowy = wiersz;
                                            kolumnaTymczasowa = kolumna;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 0) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (kolumna == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz + 1, kolumna] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz - 1, kolumna] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz == 9) {

                                        if ((plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna - 1] == 0) ||
                                            (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && plansza[wiersz, kolumna + 1] == 0)) {

                                            plansza[wiersz, kolumna] = 4;

                                            iloscCzesciStatku++;

                                            Console.ForegroundColor = ConsoleColor.DarkGreen;
                                            Console.WriteLine($"Statek ustawiony!\n");
                                            Console.ResetColor();

                                        }

                                    } else if (wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4
                                            && (plansza[wiersz - 1, kolumna] == 0) && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0)) ||
                                            wiersz < plansza.GetLength(0) - 1 && (plansza[wierszTymczasowy, kolumnaTymczasowa] == 4 && (plansza[wiersz + 1, kolumna] == 0)
                                            && (plansza[wiersz, kolumna + 1] == 0) && (plansza[wiersz, kolumna - 1] == 0))) {

                                        plansza[wiersz, kolumna] = 4;

                                        wierszTymczasowy = wiersz;
                                        kolumnaTymczasowa = kolumna;

                                        iloscCzesciStatku++;

                                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                                        Console.WriteLine($"Statek ustawiony!\n");
                                        Console.ResetColor();

                                    } else {

                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Nie możesz w tym miejscu postawić statku. Statki nie mogą być obok siebie!\n");
                                        Console.ResetColor();

                                    }

                                } else {

                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine($"Części statków muszą być obok siebie.\n");
                                    Console.ResetColor();

                                }
                            }

                        } else {

                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("To pole jest już zajęte! Wybierz inne.\n");
                            Console.ResetColor();

                        }

                    } else {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Nieprawidłowe współrzędne. Spróbuj ponownie.\n");
                        Console.ResetColor();

                    }

                    wyswietlPlansze(plansza);

                }
            }
        }

        static void wyswietlPlanszeOrientacyjna(int[,] plansza) {

            Console.ForegroundColor = ConsoleColor.DarkGray;

            Console.WriteLine("    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int wiersz = 0; wiersz < plansza.GetLength(0); wiersz++) {

                Console.Write($"{wiersz} | ");

                for (int kolumna = 0; kolumna < plansza.GetLength(1); kolumna++) {

                    if (plansza[wiersz, kolumna] == 0) {

                        Console.Write("_ ");

                    } else if (plansza[wiersz, kolumna] == 5) {

                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("X ");
                        Console.ForegroundColor = ConsoleColor.DarkGray;

                    }
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            Console.ResetColor();

        }

        static void strzelanie(int[,] planszaGracza, int[,] planszaPrzeciwnikaOrientacyjna) {

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Podaj pierwszą współrzędną : ");
            string wierszString = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Podaj drugą współrzędną : ");
            string kolumnaString = Console.ReadLine();

            if (wierszString.Equals("") || kolumnaString.Equals("")) {

                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"Współrzędna nie może być pusta.\n\n");
                Console.ResetColor();

            } else {

                Console.ForegroundColor = ConsoleColor.Magenta;

                int wiersz = int.Parse(wierszString);
                int kolumna = int.Parse(kolumnaString);

                Console.WriteLine();

                if ((planszaGracza[wiersz, kolumna] == 1) || (planszaGracza[wiersz, kolumna] == 2) || (planszaGracza[wiersz, kolumna] == 3) || (planszaGracza[wiersz, kolumna] == 4)) {

                    if (wiersz >= 0 && wiersz < planszaGracza.GetLength(0) && kolumna >= 0 && kolumna < planszaGracza.GetLength(1)) {

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine($"Statek trafiony !\n");
                    Console.ResetColor();

                    planszaGracza[wiersz, kolumna] = 0;
                    planszaPrzeciwnikaOrientacyjna[wiersz, kolumna] = 5;

                    Console.ResetColor();

                    } else {

                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nNieprawidłowe współrzędne. Spróbuj ponownie.\n");
                        Console.ResetColor();

                    }

                } else {

                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Pudło albo już trafiono !\n");
                    Console.ResetColor();
                }
            }
        }

        static void iloscStatkowNaPlanszy(int[,] plansza, string gracz) {

            int jednomasztowy = 4;
            int dwumasztowy = 3;
            int trzymasztowy = 2;
            int czteromasztowy = 1;

            while (jednomasztowy >= 1) {

                if (jednomasztowy > 1) {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"Ustaw {jednomasztowy} jednomasztowe statki\n");
                    Console.ResetColor();

                } else {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nUstaw {jednomasztowy} jednomasztowy statek\n");
                    Console.ResetColor();

                }

                wyswietlPlansze(plansza);
                ustawStatekJednomasztowy(plansza);

                jednomasztowy--;

            }

            Console.WriteLine($"-------------------------------------------\n");

            while (dwumasztowy >= 1) {

                if (dwumasztowy > 1) {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nUstaw {dwumasztowy} dwumasztowe statki\n");
                    Console.ResetColor();

                } else {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nUstaw {dwumasztowy} dwumasztowy statek\n");
                    Console.ResetColor();

                }

                wyswietlPlansze(plansza);
                ustawStatekDwumasztowy(plansza);

                dwumasztowy--;

            }

            Console.WriteLine($"-------------------------------------------\n");

            while (trzymasztowy >= 1) {

                if (trzymasztowy > 1) {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nUstaw {trzymasztowy} trzymasztowe statki\n");
                    Console.ResetColor();

                } else {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nUstaw {trzymasztowy} trzymasztowy statek\n");
                    Console.ResetColor();

                }

                wyswietlPlansze(plansza);
                ustawStatekTrzymasztowy(plansza);

                trzymasztowy--;

            }

            Console.WriteLine($"-------------------------------------------\n");

            while (czteromasztowy >= 1) {

                if (czteromasztowy > 1) {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nUstaw {czteromasztowy} czteromasztowe statki\n");
                    Console.ResetColor();

                } else {

                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\nUstaw {czteromasztowy} czteromasztowy statek\n");
                    Console.ResetColor();

                }

                wyswietlPlansze(plansza);
                ustawStatekCzteromasztowy(plansza);

                czteromasztowy--;

            }

            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine($"\nStatki dla {gracz} zostały ustawione\n");
            Console.ResetColor();

            wyswietlPlansze(plansza);

        }

        static void sprawdzeniePlanszy(int[,] plansza, string gracz) {

            int iloscWolnychPol = 0;

            for (int wiersz = 0; wiersz < plansza.GetLength(0); wiersz++) {

                for (int kolumna = 0; kolumna < plansza.GetLength(1); kolumna++) {

                    if (plansza[wiersz, kolumna] == 0) {

                        iloscWolnychPol++;

                    }
                }
            }

            if (iloscWolnychPol == 100) {

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Koniec gry ! Wygrywa gracz {gracz} ! Gratuluje ! Dziękuje za grę.");
                Console.ResetColor();

                Thread.Sleep(5000);
                Environment.Exit(0);

            }

        }

        static void Main(string[] args) {

            int[,] planszaGracza1 = new int[10, 10];
            int[,] planszaGracza2 = new int[10, 10];

            int[,] planszaOrientacyjnaGracz1 = new int[10, 10];
            int[,] planszaOrientacyjnaGracz2 = new int[10, 10];

            wstep();

            Console.WriteLine("Podaj imię gracza numer 1 : ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string gracz1 = Console.ReadLine();
            Console.WriteLine();
            Console.ResetColor();

            Console.WriteLine("Podaj imię gracza numer 2 : ");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            string gracz2 = Console.ReadLine();
            Console.WriteLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Naciśnij dowolny klawisz aby kontynułować");
            Console.ReadKey();
            Console.WriteLine("Ładowanie...");
            Thread.Sleep(3000);
            Console.Clear();
            Console.ResetColor();

            Console.WriteLine($"\n PLANSZA GRACZA {gracz1} \n\n");

            iloscStatkowNaPlanszy(planszaGracza1, gracz1);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nGotowe ? Naciśnij dowolny klawisz aby gracz {gracz2} mógł teraz wypełnić swoją plansze");
            Console.ReadKey();
            Console.WriteLine("Ładowanie...");
            Thread.Sleep(3000);
            Console.Clear();
            Console.ResetColor();

            Console.WriteLine($"\n PLANSZA GRACZA {gracz2} \n\n");

            iloscStatkowNaPlanszy(planszaGracza2, gracz2);

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\nPo naciśnięciu dowolnego klawiszu rozpoczną się naprzemienne tury podczas których będziesz musiał/ła rozstrzelać wrogie statki. Gotowy?");
            Console.ReadKey();
            Console.WriteLine("Ładowanie...");
            Thread.Sleep(3000);
            Console.Clear();
            Console.ResetColor();

            bool ustawiono2 = false;

            while (!ustawiono2) {

                Console.WriteLine($"\nTura gracza {gracz1}\n");

                wyswietlPlanszeOrientacyjna(planszaOrientacyjnaGracz1);
                strzelanie(planszaGracza2, planszaOrientacyjnaGracz1);
                sprawdzeniePlanszy(planszaGracza2, gracz1);

                Console.WriteLine($"-------------------------------------------\n");

                Console.WriteLine($"\nTura gracza {gracz2}\n");

                wyswietlPlanszeOrientacyjna(planszaOrientacyjnaGracz2);
                strzelanie(planszaGracza1, planszaOrientacyjnaGracz2);
                sprawdzeniePlanszy(planszaGracza1, gracz2);

                Console.WriteLine($"-------------------------------------------\n");

            }
        }
    }
}


