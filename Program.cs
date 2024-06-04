//Three room-Gold, Silver, Bronze.
//Define Services;
//Book any one room.
using System;
using System.IO;
public class Room
{
   public  string? RoomRank{get;set;}
   public  int? Price{get;set;}//Per Day Price;
   public Room()
   {
    RoomRank="";
    Price=0;
   }
   public void SetPrice()
    {
        if(RoomRank=="Gold")
        {
            Price+=5000;
        }
        else if(RoomRank=="Silver")
        {
            Price+=3000;
        }
        else if(RoomRank=="Bronze")
        {
            Price+=1000;
        }
        else{
            Console.WriteLine("Invalid Room");
        }
    }
}
public class Services
{
    //services Spa, Massage, Food Delivery etc.
    //Prices for these services are 800, 500, 400 etc.
     
   public static string? Service{get;set;}
   public static void AddServicesPrice(Room r)
    {string BookingFile="Booking.txt";

        if(Service=="Spa")
        { File.AppendAllText(BookingFile,Service+", ");
            r.Price+=800;
        }
        else if(Service=="Massage")
        { File.AppendAllText(BookingFile,Service+", ");
            r.Price+=500;
        }
        else if(Service=="Food Delivery")
        { File.AppendAllText(BookingFile,Service+", ");
            r.Price+=400;
        }
        else if(Service=="Gym")
        { File.AppendAllText(BookingFile,Service+", ");
            r.Price+=500;
        }
        else if(Service=="Swimming Pool")
        {
            r.Price+=200;
            File.AppendAllText(BookingFile,Service+", ");
        }
        else if(Service=="Laundry")
        {
            r.Price+=400;
            File.AppendAllText(BookingFile,Service+", ");
        }
        else{
            Console.WriteLine("Invalid Service");
        }
    }

}
public class Customer
{
   public string? Name{get;set;}
   public string? Id{get;set;}
   public int? No_of_Days{get;set;}
   //SetPrice By using No of Days.
   public void SetPrice(Room r)
   {
        r.Price*=No_of_Days;
   }
   public void SetPriceForDD(Room r)
   { string BookingFile="Booking.txt";
       Console.WriteLine("Enter the Sequence of the Rooms you want to Book");
        File.AppendAllText(BookingFile,"Sequence of the Stay : ");
       for(int i=0;i<No_of_Days;i++)
       {
        string? Rank=(Console.ReadLine());
         if(Rank=="Gold")
        {
            r.Price+=5000;
           
        }
        else if(Rank=="Silver")
        {
            r.Price+=3000;
           
        }
        else if(Rank=="Bronze")
        {
            r.Price+=1000;
           
        }
        else{
            Console.WriteLine("Invalid Room");
        }
        
        if(i==No_of_Days-1)
         File.AppendAllText(BookingFile,Rank+"; ");
         else
        File.AppendAllText(BookingFile,Rank+", ");

         
       }
     
   }
}
public class Booking
{
    public static void Main()
    {
       string BookingFile="Booking.txt";

        Customer C=new Customer();
        Console.WriteLine("Enter the Name of Customer");
        C.Name=(Console.ReadLine()); 

        File.AppendAllText(BookingFile,"\nCustomer : "+C.Name+"; ");

        Console.WriteLine("Enter the Id of Customer");
        C.Id=(Console.ReadLine());
         File.AppendAllText(BookingFile," Id : "+C.Id+"; ");

         Console.WriteLine("Enter the number of Days");
         C.No_of_Days=Convert.ToInt32(Console.ReadLine());

        Room r=new Room();

        Console.WriteLine("Do you want to stay in same room for all "+C.No_of_Days+" days?");
        string? N=(Console.ReadLine());    
    
        if(N=="Yes")
        {   Console.WriteLine("Enter the rank of the room you want to book");
            r.RoomRank=(Console.ReadLine());
            File.AppendAllText(BookingFile," RoomRank : "+r.RoomRank+"; ");
            r.SetPrice();
            C.SetPrice(r);
            File.AppendAllText(BookingFile," No of Days of Stay : "+C.No_of_Days+"; ");
        }
        else if(N=="No")
        {
            C.SetPriceForDD(r);
           
        }
        
           

        Console.WriteLine("Enter the Services you want");
        File.AppendAllText(BookingFile," Services : ");
       
        while(true)
        {string? s=(Console.ReadLine());
            if(s=="stop" || s=="none")
            {File.AppendAllText(BookingFile,"; ");
                break;
            }
             else if(s=="none")
            {File.AppendAllText(BookingFile,"None ; ");
                break;
            }
            else
            {
                Services.Service=s;
                Services.AddServicesPrice(r);
            }
        }

        Console.WriteLine("Total Price is: "+r.Price);
          File.AppendAllText(BookingFile,"Total Price : "+r.Price.ToString());  

    }
}