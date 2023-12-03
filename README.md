# Actividad-7
### Nombre: Erick Ramírez  

# API de Pacientes  

A continuación se muestran los detalles de cómo realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) utilizando Postman.  

## Configuración inicial  

Antes de realizar las solicitudes, asegúrate de realizar el iniciar el login usando la siguiente direccion
```bash
http://localhost:5149/api/doctor/login?username=usuario&password=contraseña
```
Y en parametros se debe incluir:  
username: usuario  
password: contraseña   

![Ejemplo de imagen](images/login_post.JPG)

Debería recibir un 'Status: 200 OK' junto con el token para usar en las siguientes peticiones  

![Ejemplo de imagen](images/response_token.JPG)  

# Pacientes  

Una vez que se obtenga el `token` tenemos que ubicarlo en la pestaña de Authorization y en `Type` seleccionamos Bearer Token y pegamos el Token obtenido anteriormente  

![Ejemplo de imagen](images/token.JPG)  

## Obtener todos los pacientes

- **Método:** `GET`
- **URL:** `http://localhost:5149/api/paciente`
- **Descripción:** Obtiene todos los pacientes almacenados.

Resultado esperado:  
![Ejemplo de imagen](images/pacientes_all_get.JPG)

## Obtener un paciente por ID

- **Método:** `GET`
- **URL:** `http://localhost:5149/api/paciente/1`
- **Descripción:** Obtiene los detalles de un paciente específico por su ID.

Resultado esperado:  
![Ejemplo de imagen](images/pacientes_id_get.JPG)post_create_conf

## Crear un nuevo paciente

- **Método:** `POST`
- **URL:** `http://localhost:5149/api/paciente`
- **Descripción:** Crea un nuevo paciente.
- **Datos del cuerpo (Body):** Se debe enviar el id y el nombre del paciente como el siguiente ejemplo en formato JSON
```bash
{
    "id": 4,
    "nombre": "Israel"
}
```
![Ejemplo de imagen](images/post_create_conf.JPG)  

Resultado esperado:  
![Ejemplo de imagen](images/post_create_paciente.JPG)

## Actualizar un paciente existente

- **Método:** `PUT`
- **URL:** `https://tu-url/api/Paciente/{id}`
- **Descripción:** Actualiza los datos de un paciente existente por su ID.
- **Datos del cuerpo (Body):** Datos actualizados del paciente en formato JSON.

## Eliminar un paciente

- **Método:** `DELETE`
- **URL:** `https://tu-url/api/Paciente/{id}`
- **Descripción:** Elimina un paciente existente por su ID.

