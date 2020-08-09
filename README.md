# Driving History 

This application is used to track the driving history of different people. The code written processes an input file containing the driving history data. The input file is accepted as an argument given on the command line. This .NET Core application is written in C# and utilizes unit testing. 

## Requirements

Since this is a .NET Core application, .NET Core CLI must be installed to run the app.
https://dotnet.microsoft.com/download

## Running the App
1. In a terminal, navigate to the DrivingHistory/DrivingHistory folder.
1. Running the `dotnet run <filename>` command, will run the application.
1. There is already a `driver.txt` file in this folder, so running `dotnet run driver.txt` will run the application with the given input file.
1. To run the application with a different input file, move the input file into this folder and call the above command.

## Code Reasoning

### Program.cs 
Since a command line argument is required to run the application, the first thing I check for is that a command line argument is given. If it wasn't, it prints out a message and returns. Otherwise, it uses that argument and looks for an existing file that matches that name. It checks if the file exists and if it doesn't, it prints out a message and returns. 

I then created new instances of `FileAccess` and `TripHandler` so that Program.cs is orchestrating what happens in the app but the logic is contained to the appropriate class.

### FileAccess.cs
This class has one function that simply reads in the file and returns `lines` as a list of strings. The reason for this is so that this class only is responsible for reading the file. The benefit to this is that the code can be reused and does not rely on anything related to the trips. 

### TripHandler.cs
This class is responsible for all of the logic dealing with a trip. The `ParseFileData` function accepts the `lines` from above and loops through them. Within the loop, it checks to see if the first word of the line is "Driver" or "Trip". If it is "Driver", it creates a new instance of `DriverInfo` and adds it to the dictionary. If it is "Trip", the function retrieves the value from the dictionary with the Driver's name as the key. It calls `AddTrip` on the DriverInfo class. 

I decided to use a Dictionary for storing the driver's trip data because Dictionary's consist of Key/Values pairs. The benefit of a dictionary in this context is being able to quickly look up a specific driver by their name, which is the key.

The second function is `GenerateTripOutput` which creates the output list of strings. It loops through each Key/Value pair in the `DriverInfo` dictionary in descending order of miles traveled. There is a base output that every driver will receive. If a driver has trips, then they will receive information about their speed. This function is only responsible for building the strings to be outputted to make it more easily testable and more singularly focused.

The third function is `DisplayOutput` and it simply takes in a list of strings and loops through each item. It prints out each item. 

### DriverInfo.cs
This class contains the properties `DriverName`, `MilesTraveled`, and `HoursTraveled` so that other classes can access them but not set them. One of the constructors accepts a string and initializes the values and sets `DriverName` to the passed in string. Another constructor accepts a string and two doubles and sets all of the properties accordingly.

This class helps keep all of the relevant data to a driver in a centralized location and reduces complexity.

There is also a method called `AddTrip` that is in this class because it has to do with data pertaining to the driver. It accepts a string array which is the strings from the file and converts them into the appropriate values. This method also handles determining valid trips as far as the speed. If the trip is valid, then the `MilesTraveled` and `HoursTraveled` fields for the driver are updated.

### Constants.cs
This class contains the properties that relate to the driver info that should not be edited by other classes. For example, the properties `DriverCommand` and `TripCommand` help determine if the line in the file relates to a driver or if it is a line containing all the trip details. Each index in the trip line is also set to a constant in this class. This makes it easy to see what those indexes represent.





