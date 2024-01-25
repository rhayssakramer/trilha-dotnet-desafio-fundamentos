using AppEstacionamento.Models;
using System;

// Coloca o encoding para UTF8 para exibir acentuação
Console.OutputEncoding = System.Text.Encoding.UTF8;

//Entrada incial do programa
Console.Clear();
Console.WriteLine("Sejam Bem-Vindos ao Park Olinda Estacionamento!\n" + "Estamos comprometidos em fornecer a você uma experiência de estacionamento segura e diferente.\n" + "Aproveite sua estadia!");

//Instância da class Estacionamento
Estacionamento estacionamento = new Estacionamento();
estacionamento.MenuInicial();