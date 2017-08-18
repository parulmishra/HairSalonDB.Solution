# _HAIR SALON_

#### _Hair Salon 08.18.17_

#### By _**Parul Mishra Dubedy**_

## Description

_This Mvc application maintains a database for stylists and theis clients and allows different operations like create, read, update and delete to be performed on their records._

| Behavior  | Input  | Output  |
|---|---|---|
|1.  When the user clicks on the  button `View Stylists`, a list of all the stylists will be displayed. | > button clicked `View Stylists` | > parul <br> > nikki 
|2.  When the user clicks on the  button `View Clients`, a list of all the clients will be displayed. | > button clicked `View Clients` | > client1 <br> > client2  
|3.  When the user clicks on the link of stylist name on the all stylist page this leads to the stylist detail page and all the information about specific stylist is displayed. | > parul is clicked | >name: parul <br>>expertise: haircut <br>>experience:2 <br>>rate:100
|4.  When the user enters a record for client and click on the `Add` button on ClientForm page then a record is created on the client table.| > information entered: name:client1 <br>>email:client1@gmail.com <br>>phone:1234567891 | a record with same information is created. 
|5.  When the user a record for stylist and click on the `Add` button on Stylist page then a record is created on the stylist table.| > information entered: name:parul <br>>phone:1234567891 <br>>expertise: haircut <br>>experience:2 <br>>rate:100 | a record with same information is created.  
|6.  When the user clicks on the button `delete all stylists` then all the stylists from the table will be deleted. | > List of Stylists: parul, nikki <br>> button is clicked  | message: All the stylists have been deleted.
|7.  When the user clicks on the button `delete all clients` for a particular stylist then all the clients forthat specific stylist are deleted from the table. | > List of Clients for stylist Parul: client1, client2 <br>> button is clicked  | message: All the clients for Parul have been deleted.
|8. When the user wants to update the information for any client then on clicking the `upadate` button on the clients details page the information can be deleted. | > previous information for client: name:client1 <br>>email:client1@gmail.com <br>>phone:1234567891  <br> | name:client1 <br>>email:client1@gmail.com <br>>phone:9876543210  


## Setup/Installation Requirements

* _Clone this repository_

## Known Bugs

* _No known bugs at this time_

## Technologies Used

_HTML_
_CSS_
_BootStrap_
_MVC_
_C#_
_MSTest_
_MAMP_
### License

This software is licensed by the MIT License

Copyright (c) 2017 **Parul Mishra Dubedy**
