// ŹRÓDŁO Z KTÓREGO ZACZERPNEŁAM POMOCY PODCZAS TWORZENIA PROJEKTU : https://learn.microsoft.com/pl-pl/visualstudio/get-started/csharp/tutorial-windows-forms-match-game-play?view=vs-2022&tabs=csharp
// Tło aplikacji wraz z zdjęciami guzików są z internetu. Karty są rysowane osobiście.

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace AB_71555_MEMO {

    public class AB_71555_Ikony
    {
        public List<string> AB_71555_listaLiter { get; } // zmienna która ma za zadanie pobierać zawartość listy

        // Metoda która odpowiada za stworzenie listy liter, która ma za zadanie pomóc dopasować karty do siebie
        public AB_71555_Ikony()
        {
            AB_71555_listaLiter = new List<string>()
            {
                "!", "!", "N", "N", ",", ",", "k", "k",
                "b", "b", "v", "v", "w", "w", "z", "z",
                "a", "a", "s", "s", "d", "d", "e", "e",
                "q", "q", "m", "m", "r", "r", "t", "t"
            };
        }
    }

    public partial class AB_71555_MEMO : Form {

        private List<string> AB_71555_listaLiter; // zmienna pomocnicza do przekopiowania listy z klasy AB_71555_Ikony

        Label AB_71555_pierwszeNaciesniecie = null; //służy do porównania pary.
        Label AB_71555_drugieNacisniecie = null; // służy do porównania pary.

        int AB_71555_startStop = 0;
        int AB_71555_czyKliknietoStart = 0; // zmienna oznaczająca, czy gra została rozpoczęta (1 = tak, 0 = nie).
        int AB_71555_iloscPar = 0; // licznik znalezionych par – po 16 gra zostaje zakończona.

        Random AB_71555_random = new Random(); // Generator losowych liczb – używany do losowania ikon (liter).

        // Metoda służy do przypisywania losowych liter do labli, po to aby porównywać łatwo karty z sobą oraz przypisac im obrazki. Każda litera występuje dwa razy.
        private void AB_71555_przypiszIkoneDoElementu()
        {
            AB_71555_Ikony AB_71555_ikonyKart = new AB_71555_Ikony();
            AB_71555_listaLiter = new List<string>(AB_71555_ikonyKart.AB_71555_listaLiter); // zmienna kopjująca liste

            foreach (Control AB_71555_kontrolka in AB_71555_tableLayoutPanel.Controls)
            {
                Label AB_71555_ikonaLabel = AB_71555_kontrolka as Label;

                if (AB_71555_ikonaLabel != null)
                {
                    int AB_71555_randomowyElement = AB_71555_random.Next(AB_71555_listaLiter.Count);
                    string AB_71555_symbol = AB_71555_listaLiter[AB_71555_randomowyElement];

                    AB_71555_ikonaLabel.Tag = AB_71555_symbol;
                    AB_71555_ikonaLabel.Text = "";
                    AB_71555_listaLiter.RemoveAt(AB_71555_randomowyElement);
                }

                if (AB_71555_ikonaLabel.Tag == "!") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "N") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == ",") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "k") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "b") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "v") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "w") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "z") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "a") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "s") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "d") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "e") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "q") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "m") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "r") AB_71555_ikonaLabel.Image = null;
                else if (AB_71555_ikonaLabel.Tag == "t") AB_71555_ikonaLabel.Image = null;
            }
        }

        // Metoda sprawdza, czy gracz odkrył wszystkie 16 par.
        // Jeśli tak – wyświetla komunikat z gratulacjami.
        private void AB_71555_czyWygrana() {

            AB_71555_iloscPar++;

            if (AB_71555_iloscPar == 16) {

                MessageBox.Show("Udało ci się odkryć wszystkie pary!", "GRATULACJE");

            }

        }

        // Główny konstruktor aplikacji
        public AB_71555_MEMO() {

            InitializeComponent();
        
        }

        // Obsługa zdarzenia zakończenia timera.
        // Ukrywa obrazy na dwóch niepasujących labelach
        // i resetuje kliknięcia do stanu początkowego.
        private void AB_71555_timer_Tick(object sender, EventArgs e) {

            AB_71555_timer.Stop();

            AB_71555_pierwszeNaciesniecie.Image = null;
            AB_71555_drugieNacisniecie.Image = null;

            AB_71555_pierwszeNaciesniecie = null;
            AB_71555_drugieNacisniecie = null;

        }

        // Metoda wykonująca działania po naciśnięciu jakiegoś lable, odpowiada za spawdzanie kliknięć, odpowiedni sposób działania aplikacji, aby nie wyrzucało błędów, odpowiada za odpowiednie wyświetlanie ikon.
        private void AB_71555_MEMO_Click(object sender, EventArgs e) {

            if (AB_71555_czyKliknietoStart == 0) {

                return;

            }

            if (AB_71555_timer.Enabled == true) {

                return;

            }

            Label AB_71555_nacisnietyLabel = sender as Label; // Label, który został kliknięty przez gracza.

            if (AB_71555_nacisnietyLabel.Tag.ToString() == "x") {

                return;

            }

            if (AB_71555_nacisnietyLabel != null) {

                if (AB_71555_pierwszeNaciesniecie == null) {

                    AB_71555_pierwszeNaciesniecie = AB_71555_nacisnietyLabel;    

                    if (AB_71555_nacisnietyLabel.Tag == "!") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona1;
                    else if (AB_71555_nacisnietyLabel.Tag == "N") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona2;
                    else if (AB_71555_nacisnietyLabel.Tag == ",") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona3;
                    else if (AB_71555_nacisnietyLabel.Tag == "k") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona4;
                    else if (AB_71555_nacisnietyLabel.Tag == "b") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona5;
                    else if (AB_71555_nacisnietyLabel.Tag == "v") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona6;
                    else if (AB_71555_nacisnietyLabel.Tag == "w") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona7; 
                    else if (AB_71555_nacisnietyLabel.Tag == "z") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona8;
                    else if (AB_71555_nacisnietyLabel.Tag == "a") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona9;
                    else if (AB_71555_nacisnietyLabel.Tag == "s") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona10;
                    else if (AB_71555_nacisnietyLabel.Tag == "d") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona11;
                    else if (AB_71555_nacisnietyLabel.Tag == "e") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona12;
                    else if (AB_71555_nacisnietyLabel.Tag == "q") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona13;
                    else if (AB_71555_nacisnietyLabel.Tag == "m") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona14;
                    else if (AB_71555_nacisnietyLabel.Tag == "r") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona15;
                    else if (AB_71555_nacisnietyLabel.Tag == "t") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona16;

                    return;

                }

                AB_71555_drugieNacisniecie = AB_71555_nacisnietyLabel;

                if (AB_71555_nacisnietyLabel.Tag == "!") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona1;
                else if (AB_71555_nacisnietyLabel.Tag == "N") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona2;
                else if (AB_71555_nacisnietyLabel.Tag == ",") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona3;
                else if (AB_71555_nacisnietyLabel.Tag == "k") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona4;
                else if (AB_71555_nacisnietyLabel.Tag == "b") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona5;
                else if (AB_71555_nacisnietyLabel.Tag == "v") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona6;
                else if (AB_71555_nacisnietyLabel.Tag == "w") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona7;
                else if (AB_71555_nacisnietyLabel.Tag == "z") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona8;
                else if (AB_71555_nacisnietyLabel.Tag == "a") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona9;
                else if (AB_71555_nacisnietyLabel.Tag == "s") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona10;
                else if (AB_71555_nacisnietyLabel.Tag == "d") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona11;
                else if (AB_71555_nacisnietyLabel.Tag == "e") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona12;
                else if (AB_71555_nacisnietyLabel.Tag == "q") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona13;
                else if (AB_71555_nacisnietyLabel.Tag == "m") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona14;
                else if (AB_71555_nacisnietyLabel.Tag == "r") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona15;
                else if (AB_71555_nacisnietyLabel.Tag == "t") AB_71555_nacisnietyLabel.Image = Properties.Resources.ikona16;
                
                if (AB_71555_nacisnietyLabel == AB_71555_pierwszeNaciesniecie) {
                    AB_71555_nacisnietyLabel.Image = null;
                    AB_71555_pierwszeNaciesniecie = null;
                 
                    return;
                }

                if (AB_71555_pierwszeNaciesniecie.Tag.ToString() == AB_71555_drugieNacisniecie.Tag.ToString()) {

                    AB_71555_pierwszeNaciesniecie.Tag = "x";
                    AB_71555_drugieNacisniecie.Tag = "x";

                    AB_71555_pierwszeNaciesniecie = null;
                    AB_71555_drugieNacisniecie = null;

                    AB_71555_czyWygrana();

                    return;

                }

                AB_71555_timer.Start();

            }

        }

        // Metoda zamyka aplikację po kliknięciu przycisku "Exit".
        private void AB_71555_przyciskExit_Click(object sender, EventArgs e) {

            Close();

        }
        
        // Metoda pałzująca działanie aplikacji do puki nie wyłączy się/zatwierdzi okna.
        private void AB_71555_przyciskStop_Click(object sender, EventArgs e) {

            if (AB_71555_czyKliknietoStart == 1) {

            }

            AB_71555_startStop++;

            Label AB_71555_czas = new Label();
            AB_71555_czas.BackColor = System.Drawing.Color.Red;
            AB_71555_czas.Font = new Font(AB_71555_czas.Font.FontFamily, 14);
            AB_71555_czas.Bounds = new Rectangle(860, 630, 140, 50);
            AB_71555_czas.TextAlign = ContentAlignment.MiddleCenter;
            AB_71555_czas.Text = "Wstrzymano Grę";
            this.Controls.Add(AB_71555_czas);

            if (AB_71555_startStop == 1) {

                AB_71555_czas.Visible = true;

                MessageBox.Show("Gra przerwana. Do puki nie zatwierdzisz okienka albo go nie wyłączysz, gra nie będzie kontynuowana.", "STOP");

                AB_71555_czas.Visible = false;
                AB_71555_startStop = 0;

            }
            

            Label AB_71555_timer = new Label();


        }

        // Metoda pauzuje grę do czasu, aż użytkownik zamknie/zatwierdzi okno komunikatu.
        // Działa tylko po rozpoczęciu gry.
        private void AB_71555_przyciskReset_Click(object sender, EventArgs e) {

            if (AB_71555_czyKliknietoStart == 1) {

                MessageBox.Show("Zresetowano karty, możesz teraz grać od nowa", "RESET");
                AB_71555_przypiszIkoneDoElementu();

            }

        }

        // Metoda która rozpoczyna gre, jednorazowo, potem aż do wyłączenia gry nie będzie można ponownie kliknąć tego przycisku
        private void AB_71555_przyciskStart_Click(object sender, EventArgs e) {

            if (AB_71555_czyKliknietoStart == 1) {

                return;

            } else { 
            
            AB_71555_czyKliknietoStart = 1;            

            AB_71555_przypiszIkoneDoElementu();

            }

        }
    }
}
