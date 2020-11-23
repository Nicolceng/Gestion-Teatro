using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Practica4Nico
{
    /// <summary>
    /// Lógica de interacción para Aliens.xaml
    /// </summary>
    public partial class Aliens : Window
    {
        public Aliens()
        {
            InitializeComponent();
        }


        List<Asiento> listaasientos;

        Sala salas1;

        public Aliens(List<Asiento> listaasiento, Sala s2)
        {
            listaasientos   = listaasiento;

            salas1 = s2;

            InitializeComponent();

            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);

            //Declaracion numero de filas y columnas dinamicos
            int nFilas = 5;
            int nColumnas = 4;

            //Fors para añadir al grid dinamicamente filas y columnas
            for (int f = 0; f < nFilas; f++)
                grid.RowDefinitions.Add(new RowDefinition());
            for (int c = 0; c < nColumnas; c++)
                grid.ColumnDefinitions.Add(new ColumnDefinition());


            //Fors anidados para la creacion de los botones, pasandole al setrow y al setcolumn el objeto boton con la posicion de filas y columnas, el children los añade todos
            for (int i = 0; i <= nColumnas; i++)
            {
                for (int m = 0; m <= nFilas; m++)
                {
                    Button b = new Button();
                 
                    b.Content = string.Format(i + "-" + m);
                    Grid.SetRow(b, i);
                    Grid.SetColumn(b, m);
                    grid.Children.Add(b);
                }


                //Para pintar todos los asientos en verde
                UIElementCollection e = grid.Children;
                foreach (UIElement x in e)
                {
                    ((Button)x).Background = Brushes.Green;
                }
            }
            //wrappanel
            UIElementCollection j = grid.Children;


            //Recorro el wrappanel
            foreach (UIElement ru in j)
            {

                //Recorro la lista
                foreach (Asiento l in salas1.Listasientos)
                {

                    String str = l.Fila + "-" + l.Columna;

                    //Si coincide se seteara el color a rojo o violeta dependiendo del estado
                    if (str.Equals(((Button)ru).Content.ToString()))
                    {
                        if (l.Estado.Equals("ocupado"))
                        {
                            //Si es ocupado en rojo
                            ((Button)ru).Background = Brushes.Red;
                        }
                        else
                        {
                            //Si es reservado en violeta
                            ((Button)ru).Background = Brushes.Violet;
                        }
                    }

                }

                //Metodo click en todos los botones de la sala
                ((Button)ru).Click += Button_Click;

            }


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button boton = (Button)sender;

            if (boton.Background == Brushes.Red || boton.Background == Brushes.Violet)
            {
                //Si se cumple la condicion de los colores aparece la ventana de cancelar
                Cancelar can = new Cancelar(boton, salas1);
                can.Show();


                foreach (Asiento ass in salas1.Listasientos)
                {
                    String cont = ass.Fila + "-" + ass.Columna;

                    //Si coincide con el contenido se borra de la lista
                    if (cont.Equals((boton.Content.ToString())))
                    {
                        salas1.Listasientos.Remove(ass);
                        break;
                    }
                }


            }
            else
            {
                //Si no se hace  un show de la otra ventana de reservar y comprar
                CompraYReserva f2 = new CompraYReserva(boton, salas1);
                f2.Show();
            }

        }
    }
}
