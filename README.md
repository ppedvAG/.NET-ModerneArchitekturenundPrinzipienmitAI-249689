# Moderne Architekturen und Designprinzipien
Kurs Repository zu Kurs .NET - Moderne Architekturen und Designprinzipien der ppedv AG

## M001 | Was Architektur ist

- [ ] Ebenenmodell
- [ ] Aspekte, Richtlinien, Analyse
- [ ] 3P-Regel: Product, Process, People
- [ ] Funktional vs. Nicht-Funktional
- [ ] Kosten und Technische Schulden

## M002 | Architekturüberblick

- [ ] Cargo Cult Programming
- [ ] Überblick verschiedener Architekturen
- [ ] Beispiel Clean-Architecture "Todo List"

```bash
dotnet new install Clean.Architecture.Solution.Template
```

## M003 | Design Patterns

- [ ] Relevanz und Entwicklung der Muster
- [ ] Creational Patterns: Wie werden Objekte erzeugt?
  *  FactoryMethod als PizzaShop
  *  BuilderPattern als PizzaConfigurator
- [ ] Structural Patterns: Wie werden Objekte verbunden und integriert?
  *  Decorator: Pizza schneiden und verpacken
  *  Adapter: Pfannen-Pizza als "normale" Pizza bestellen
- [ ] Behavioral Patterns: Wie verhalten sich Objekte und Objektstrukturen?
  *  Strategy: Pizza mit einem Fahrzeug ausliefern
- [ ] Lab Payment-Service

## M004 | Design Principles

- [ ] Prinzipien und Code-Smells
- [ ] SOLID Bewertung
- [ ] Säulen der OOP, Kohäsion und Kopplung
- [ ] Beispiele zu ISP und DIP
- [ ] Lab Artikel: Ist Architektur überbewertet?

## M005 | Event Sourcing

- [ ] Domain Driven Design
- [ ] Datenpersistenz
- [ ] Beispiel Student Course
- [ ] Lab Bankkonto

## M006 | WebAPI mit CQRS

- [ ] Repository Pattern
- [ ] Mediator Pattern
- [ ] Service API
- [ ] Beispiel Auftragsverwaltung
- [ ] Lab Bankkonto API

## M007 | Business Anwendung

- [ ] Eigene Geschäftsanwendung entwerfen
- [ ] Klassendiagramm erstellen mit draw.io
- [ ] Domänen-modell generieren lassen
- [ ] DataAccess Projekt in Infrastructure
  * Microsoft.EntityFrameworkCore.SqlServer
  * Microsoft.EntityFrameworkCore.Tools
- [ ] Testdatenbank mit Entity Framework
- [ ] Testdaten generieren lassen
  * LocalDB verwenden (Kommandozeile: `sqllocaldb create|start|stop|info <instanceName>`)
  * [Testing Strategien gegen Datenbank](https://learn.microsoft.com/de-de/ef/core/testing/)
- [ ] WebAPI Projekt in Presentation erstellen
  * Microsoft.EntityFrameworkCore.Design
  * Design ist notwendig um das Migrationsskript zu erstellen

```bash
// Package Manager Console aufrufen
// Default project: ppeat.DataAccess
// Startprojekt: ppeat.UI.WebApi

Add-Migration InitPpeatDbData 

Update-Database

```
- [ ] Weitere Front-Ends erstellen