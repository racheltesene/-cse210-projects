using System;

// Address class to represent event addresses
public class Address
{
    public string Street { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string ZipCode { get; set; }

    public Address(string street, string city, string state, string zipCode)
    {
        Street = street;
        City = city;
        State = state;
        ZipCode = zipCode;
    }

    public override string ToString()
    {
        return $"{Street}, {City}, {State}, {ZipCode}";
    }
}

// Base Event class
public class Event
{
    private string title;
    private string description;
    private DateTime date;
    private TimeSpan time;
    private Address address;

    public Event(string title, string description, DateTime date, TimeSpan time, Address address)
    {
        this.title = title;
        this.description = description;
        this.date = date;
        this.time = time;
        this.address = address;
    }

    public string GenerateStandardDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public string GenerateFullDetails()
    {
        return $"Title: {title}\nDescription: {description}\nDate: {date.ToShortDateString()}\nTime: {time}\nAddress: {address}";
    }

    public string GenerateShortDescription()
    {
        return $"Type: Generic Event\nTitle: {title}\nDate: {date.ToShortDateString()}";
    }
}

// Derived class for Lectures
public class Lecture : Event
{
    private string speaker;
    private int capacity;

    public Lecture(string title, string description, DateTime date, TimeSpan time, Address address, string speaker, int capacity)
        : base(title, description, date, time, address)
    {
        this.speaker = speaker;
        this.capacity = capacity;
    }

    public new string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nType: Lecture\nSpeaker: {speaker}\nCapacity: {capacity}";
    }
}

// Derived class for Receptions
public class Reception : Event
{
    private string rsvpEmail;

    public Reception(string title, string description, DateTime date, TimeSpan time, Address address, string rsvpEmail)
        : base(title, description, date, time, address)
    {
        this.rsvpEmail = rsvpEmail;
    }

    public new string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nType: Reception\nRSVP Email: {rsvpEmail}";
    }
}

// Derived class for Outdoor Gatherings
public class OutdoorGathering : Event
{
    private string weatherStatement;

    public OutdoorGathering(string title, string description, DateTime date, TimeSpan time, Address address, string weatherStatement)
        : base(title, description, date, time, address)
    {
        this.weatherStatement = weatherStatement;
    }

    public new string GenerateFullDetails()
    {
        return base.GenerateFullDetails() + $"\nType: Outdoor Gathering\nWeather: {weatherStatement}";
    }
}

class Program
{
    static void Main()
    {
        // Create an instance of each type of event
        var lectureEvent = new Lecture("Programming Lecture", "Learn about C# programming", new DateTime(2023, 12, 15), new TimeSpan(14, 0, 0), new Address("123 Main St", "Cityville", "State", "12345"), "John Doe", 50);

        var receptionEvent = new Reception("Holiday Reception", "Join us for a festive celebration", new DateTime(2023, 12, 20), new TimeSpan(18, 0, 0), new Address("456 Oak Ave", "Townsville", "State", "67890"), "rsvp@example.com");

        var outdoorEvent = new OutdoorGathering("Summer Picnic", "Enjoy a day outdoors with friends", new DateTime(2023, 7, 1), new TimeSpan(12, 0, 0), new Address("789 Pine Rd", "Villageburg", "State", "54321"), "Sunny with a chance of clouds");

        // Call methods to generate marketing messages
        Console.WriteLine("Lecture Event:\n" + lectureEvent.GenerateStandardDetails() + "\n\n");
        Console.WriteLine("Reception Event:\n" + receptionEvent.GenerateFullDetails() + "\n\n");
        Console.WriteLine("Outdoor Event:\n" + outdoorEvent.GenerateShortDescription() + "\n\n");
    }
}