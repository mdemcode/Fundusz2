﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;
using Fundusz2.View;

namespace Fundusz2.Zachowania {
    public class ZamknijOkno : Behavior<Window> {

        public static readonly DependencyProperty PrzyciskProperty =
            DependencyProperty.Register(
                "Przycisk",
                typeof(Button),
                typeof(ZamknijOkno),
                new PropertyMetadata(null, PrzyciskZmieniony)
            );
        public Button Przycisk {
            get { return (Button)GetValue(PrzyciskProperty); }
            set { SetValue(PrzyciskProperty, value); }
        }
        private static void PrzyciskZmieniony(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            Window okno = (d as ZamknijOkno).AssociatedObject;
            //RoutedEventHandler button_Click = (object sender, RoutedEventArgs _e) => { okno.Close(); };
            void button_Click(object sender, RoutedEventArgs _e) {
                okno.Hide();
                if (okno is MainWindow) Application.Current.Shutdown();
            }
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }

    public class OtworzOkno : Behavior<Window> {
        public Button Przycisk { get; set; }
        protected override void OnAttached() {
            if (Przycisk != null) Przycisk.Click += Przycisk_Click;
        }
        private void Przycisk_Click(object sender, RoutedEventArgs e) {
            var opis = "Fundusz2.View." + Przycisk.Tag.ToString();
            var okno = (Window)Activator.CreateInstance(Type.GetType(opis));
            okno.ShowDialog();
        }
    }

    public class OtworzOkno1 : Behavior<Window> {

        public static readonly DependencyProperty Przycisk1Property =
            DependencyProperty.Register(
                "Przycisk1",
                typeof(Button),
                typeof(OtworzOkno1),
                new PropertyMetadata(null, PrzyciskOtwierania)
            );
        public Button Przycisk1 {
            get { return (Button)GetValue(Przycisk1Property); }
            set { SetValue(Przycisk1Property, value); }
        }

        public static readonly DependencyProperty ParametrProperty =
            DependencyProperty.Register(
                "Parametr",
                typeof(string),
                typeof(OtworzOkno1)
            );
        public string Parametr {
            get { return (string)GetValue(ParametrProperty); }
            set { SetValue(ParametrProperty, value); }
        }
        private static void PrzyciskOtwierania(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var parametr = "Fundusz2.View." + (d as OtworzOkno1).Parametr;
            // LUB //
            var opis = "Fundusz2.View." + (d as OtworzOkno1).Przycisk1.Tag.ToString();

            var okno = (Window)Activator.CreateInstance(Type.GetType(opis)); //parametr
            //Window okno2 = (d as OtworzOkno).AssociatedObject;
            //RoutedEventHandler button_Click = (object sender, RoutedEventArgs _e) => { okno.Close(); };
            void button_Click(object sender, RoutedEventArgs _e) {
                okno.ShowDialog();
            }
            if (e.OldValue != null) ((Button)e.OldValue).Click -= button_Click;
            if (e.NewValue != null) ((Button)e.NewValue).Click += button_Click;
        }
    }
}
