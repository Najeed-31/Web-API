Najeed Mubasher 6611

This is a very basic web app with a very basic html front end but the functionalities are working.

All the files are neatly arranged in their respective file directories. 

****** YOU WILL HAVE TO CHANGE THE DATABASE CONNECTION STRING IN ORDER FOR THIS TO WORK BECAUSE THE UPLOADED FILE********
************** appsettings.json CONTAINS THE CONNECTION STRING FROM THE DATABASE I'M USING AT HOME**************

************* CHANGE THE DB CONNECTION STRING TO: 
server name:OUR_DEMO_SERVER_WE_HAVE_BEEN_WORKING_ON,
database name: najeed_6611_A5 (check if this is the one),
username: curemd,
password: cure2000****************************************


The files also contain the demo weather forecast api because I was using it as a reference point throughout.


db connection and requests are working.

I could not implement the authorization through jwt feature.

the crud operations being done in the app are through stored procedures.

unfortunately, some edge cases are not catered:

1) in order for the sp to find a specific patient/doctor, their full name as it has already been stored in the db should be input otherwise
it will fail to search them.

2) while entering the doctor name, enter the prefix 'Dr. ' in order to get the results when you search by doctor as the entire string is being passed to
the api request while searching and it matches it exactly.

3) case sesitivity might also be an issue.



Handled the exception of 'field being left empty' on the front end.

handled the exception of visit type not being from the 3 preset types by adding a drop down menu for selection in the front end.

Link for Postman Collection: https://najeedmubasher31-7443490.postman.co/workspace/Najeed-Mubasher's-Workspace~cd017003-f9c8-42ac-8b7b-59a8b55219c5/collection/47607127-994c5cbe-71d9-4c8a-bea9-ed3efd935b5c?action=share&source=copy-link&creator=47607127