//these are similar to C# using statements
open canopy
open runner
open System


let baseUrl = "http://localhost:53058" 
let userEmail = "user" + DateTime.Now.Ticks.ToString() + "@company.com"
let pwd = "Test999/*"
chromeDir <- "C:\\chromedriver_win32" 
start chrome 


"Anonymous Users cannot add a new car" &&& fun _ ->
    url (baseUrl + "/Cars")
    notDisplayed "a[href='/Cars/Add']"

"Sign Up" &&& fun _ ->
    url (baseUrl + "/Account/Register")
    "#Email" << userEmail
    "#Password" << pwd
    "#ConfirmPassword" << pwd
    click "input[type=submit]"
    on baseUrl


"Log in" &&& fun _ ->
    url (baseUrl + "/Account/Login")
    "#Email" << userEmail
    "#Password" << pwd
    click "input[type=submit]"
    on baseUrl
     

"Click add link then go to create page" &&& fun _ ->
    url (baseUrl + "/cars")
    displayed "a[href='/Cars/Add']"
    click "a[href='/Cars/Add']"
    on (baseUrl + "/Cars/Add")

"New User can add a car and see only that car in the list page" &&& fun _ -> 
    url (baseUrl + "/Cars/Add")
    "input#Name" << "Accord"
    "#Make" << "Make"
    "#Model" << "Model"
    "#Year" << "2000"
    click "input[type=submit]"
    on (baseUrl + "/Cars")
    "span#total" == "1"
    ".car-name" == "Accord"

// ***
run()

printfn "press [enter] to exit"
System.Console.ReadLine() |> ignore

quit()