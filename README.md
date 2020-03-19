# odc-services
Core de servicios

El presente repositorio contiene los servicios para realizar el almacenamineto de archivos dada una configuracion, dentro de este repositorio encontraremos los siguientes servicios:

<p align="center">
	
| Servicio | Puerto |
| ------------- |  :---: |
| OpenDEVCore.Configuration  | 5006  |
| OpenDEVCore.Security  | 5007  |
| OpenDEVCore.DocConfiguration  | 5020  |
| OpenDEVCore.DocBlobStorage  | 5021 |
| OpenDEVCore.OpenDEVCore.FormService  | 5022 |

</p>

La funcionalidad de estos sera explicado a continuacion.

## ***OpenDEVCore.DocConfiguration***


Servicio el cual se encarga de crear y administrar los tipos de configuracion que tendra cada documento tales como el tipo de almacenamiento o el tipo de archivo  :+1:

Dentro de este proyecto encontraremos el archivo que se debera importar en postman para realizar las pruebas correspondientes

- **Nombre del Archivo:DocConfig.postman_collection:** 

El archivo contiene las operaciones CRUD que se pueden realizar sobre cada entidad las cuales son:

-  **TypeDocument**  
	-  ###### GetAll: Recupera los registros si estan estos tienen estado activo recuperara solo estos caso contrario recupera todos los registros ######
	- ###### Add:Añande una nueva configuracion ######
	- ###### GetByCode: Recupera una configuracion filtrandola por su codigo e institucion ######
	- ###### Find: Devolvera verdadero si encuentra una entidad filtrandola por su codigo e institucion ######
	- ###### FindByCodes: Devolvera verdadero si encuentra  todos los codigos de las configuraciones filtrandolas por institucion ######
	- ###### Edit: permite editar una configuracion ya establecida ######
	- ###### GetConfigurations: devolvera una lista de configuraciones si encuentra  todos las palabras clave filtrandolas por institucion ######
-  **Field**  
	-  ###### GetAll: Recupera los registros si estan estos tienen estado activo recuperara solo estos caso contrario recupera todos los registros ######
	- ###### Add:Añande una nueva configuracion ######
	- ###### GetByCode: Recupera una configuracion filtrandola por su codigo e institucion ######
	- ###### Find: Devolvera verdadero si encuentra una entidad filtrandola por su codigo e institucion ######
	- ###### FindByCodes: Devolvera verdadero si encuentra  todos los codigos de las configuraciones filtrandolas por institucion ######
	- ###### Edit: permite editar una configuracion ya establecida ######
-  **TypeFolder**  
	-  ###### GetAll: Recupera los registros si estan estos tienen estado activo recuperara solo estos caso contrario recupera todos los registros ######
	- ###### Add:Añande una nueva configuracion ######
	- ###### GetByCode: Recupera una configuracion filtrandola por su codigo e institucion ######
	- ###### Find: Devolvera verdadero si encuentra una entidad filtrandola por su codigo e institucion ######
	- ###### FindByCodes: Devolvera verdadero si encuentra  todos los codigos de las configuraciones filtrandolas por institucion ######
	- ###### Edit: permite editar una configuracion ya establecida ######
-  **TypeBox**  
	-  ###### GetAll: Recupera los registros si estan estos tienen estado activo recuperara solo estos caso contrario recupera todos los registros ######
	- ###### Add:Añande una nueva configuracion ######
	- ###### GetByCode: Recupera una configuracion filtrandola por su codigo e institucion ######
	- ###### Find: Devolvera verdadero si encuentra una entidad filtrandola por su codigo e institucion ######
	- ###### FindByCodes: Devolvera verdadero si encuentra  todos los codigos de las configuraciones filtrandolas por institucion ######
	- ###### Edit: permite editar una configuracion ya establecida ######
-  **TypeImage**  
	-  ###### GetAll: Recupera los registros si estan estos tienen estado activo recuperara solo estos caso contrario recupera todos los registros ######
	- ###### Add:Añande una nueva configuracion ######
	- ###### GetByCode: Recupera una configuracion filtrandola por su codigo e institucion ######
	- ###### Find: Devolvera verdadero si encuentra una entidad filtrandola por su codigo e institucion ######
	- ###### FindByCodes: Devolvera verdadero si encuentra  todos los codigos de las configuraciones filtrandolas por institucion ######
	- ###### Edit: permite editar una configuracion ya establecida ######
	

## ***OpenDEVCore.DocBlobStorage***


Servicio el cual se encarga de crear y administrar los documentos y carpetas es decir se encargadel almacenamiento del archivo en la BDD o en algun repositorio ya previamente configurado :+1:

Dentro de este proyecto encontraremos el archivo que se debera importar en postman para realizar las pruebas correspondientes

- **Nombre del Archivo:DocBlobStorage.postman_collection:** 

El archivo contiene las operaciones  que se pueden realizar cuales son:

-  **BlodStorage**  
	- ###### GuardarDocumento: Almacenara el documento con la configuracion establecida ######
	- ###### GetDocumentById:Recupera el documento completo por su id ######
	- ###### GetDocumentNoData:Recupera una lista  de documentos con su informacion basica filtrandolos por palabras clave ######
	


