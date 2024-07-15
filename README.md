# Entelgy_Pandero

# Registro de Solicitudes de Nota de Crédito

Este proyecto es una aplicación ASP.NET WebForms para la gestión de solicitudes de notas de crédito. Permite registrar, aprobar y almacenar solicitudes en una base de datos, incluyendo la funcionalidad de asignación de aprobadores y registro de actividades en una tabla de log a nivel de BD.

## Características principales

- **Registro de solicitudes:** Permite a los usuarios registrar nuevas solicitudes de nota de crédito con detalles como asociado, importe, número de cuotas y fecha.
  Obs: Solo es permitido regisrar solicitudes de Asociados existentes.
- **Validaciones:** Validación de campos de entrada, asegurando que los datos sean correctos y completos.
- **Servicios y repositorios:** Uso de servicios y repositorios para acceso a datos.

## Tecnologías utilizadas

- **ASP.NET WebForms**
- **C#**
- **SQL Server**
- **Dapper (ORM ligero para acceso a datos)**
- **Unity (Inyección de dependencias)**
- **HTML5, CSS3, JavaScript, Boostrap, SweetAlert**

## Requisitos previos

- Visual Studio 2019 o superior
- SQL Server
- .NET Framework 4.8
