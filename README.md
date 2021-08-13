The app is build on net. 5 and requires visual studio or similar to be run.
Simply open the project in visual studio and select Martian_Robots as boot option , run it and a swagger page should open up.
You can either use the swagger page , some REST program like postman or the test proyect i included to test the app.

Services :
	-MainService : Has two methods , both call to the same service and should give the same answer , the only diference is the input method , one uses a parametrized string and the other a body json, 
input can contain extra spaces or tabulations but json format must always be respected.
	-Stadistics : Basic get service that returns an historic of the robots, uses pagination , "maxItems" is the number of items per page and "skip" is the page number

Database : 
	I used SQLite for this proyect so anybody who tries to test it doesn,t have to set up a sql server , on normal circustances i would have opted for using entityFrameWork with a normal sql server like postgreSQL

Tests : 
	There is a test proyect included with the main one , there you will find the cases detailed in the pdf , also there is a coverageReport on the root on the proyect and a readme with instructions on how to update it

Important folders:
	-Controllers : Contains all the exposed REST methods
	-Services : All the api logic is here,on his root you,ll find the main services :
		-Auxiliary : Small classes that other services can use freely
		-Interfaces : Used for dependency inyection
		-Other : Currently a utils folder , with useful methods that can we used proyect wide
	-Container.cs : I extracted the dependency inyection part from Startup.cs to this class so is easier to find

Final note : Enviroment variables are left unused as the proyect is not planned to be deployed on different environments
If you have any doubt feel free to ask