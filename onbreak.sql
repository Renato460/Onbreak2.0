-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-06-2020 a las 00:21:20
-- Versión del servidor: 10.4.11-MariaDB
-- Versión de PHP: 7.4.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `onbreak`
--

DELIMITER $$
--
-- Procedimientos
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `ActiEmpresa` ()  BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message; 
	SELECT actividadempresa.IdActividadEmpresa "ID", actividadempresa.Descripcion FROM actividadempresa;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `DeleteCliente` (`_RutCliente` VARCHAR(10), OUT `respuesta` INT)  BEGIN
	DECLARE contratoExist int;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message; 
    IF _RutCliente <>"" THEN
    	SELECT COUNT(contrato.RutCliente) INTO contratoExist FROM contrato WHERE contrato.RutCliente = _RutCliente;
                IF contratoExist = 0 THEN DELETE FROM cliente WHERE cliente.RutCliente = _RutCliente;
                SET respuesta = 1;
            	ELSE SET respuesta =0;
                END IF;
    ELSE SET respuesta = 0;
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getContrato` (`_numero` VARCHAR(12), `_rutCliente` VARCHAR(10), `_idModalidad` VARCHAR(5), `_idTipoEvento` INT, OUT `respuesta` INT)  BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message; 
    case
		when _numero = '' and _rutCliente = '' and _idModalidad = '' and _idTipoEvento = 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento;
            SET respuesta = 1;
            
		when _numero <> '' and _rutCliente = '' and _idModalidad = '' and _idTipoEvento = 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.Numero = _numero;
            SET respuesta = 1;
		
        when _numero = "" and _rutCliente <> "" and _idModalidad = "" and _idTipoEvento = 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.RutCliente = _rutCliente;
            SET respuesta = 1;
		
        when _numero = "" and _rutCliente = "" and _idModalidad <> "" and _idTipoEvento = 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.IdModalidad = _idModalidad;
            SET respuesta = 1;
		
        when _numero = "" and _rutCliente = "" and _idModalidad = "" and _idTipoEvento <> 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.IdTipoEvento = _idTipoEvento;
            SET respuesta = 1;
		
        when _numero <> "" and _rutCliente <> "" and _idModalidad = "" and _idTipoEvento = 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.Numero = _numero and contrato.RutCliente = _rutCliente;
            SET respuesta = 1;
		
        when _numero = "" and _rutCliente <> "" and _idModalidad <> "" and _idTipoEvento = 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.IdModalidad = _idModalidad and contrato.RutCliente = _rutCliente;
            SET respuesta = 1;
	
		when _numero = "" and _rutCliente = "" and _idModalidad <> "" and _idTipoEvento <> 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.IdModalidad = _idModalidad and contrato.IdTipoEvento = _idTipoEvento;
            SET respuesta = 1;
            
    	when _numero <> "" and _rutCliente = "" and _idModalidad = "" and _idTipoEvento <> 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.Numero = _numero and contrato.IdTipoEvento = _idTipoEvento;
            SET respuesta = 1;
            
        when _numero <> "" and _rutCliente <> "" and _idModalidad <> "" and _idTipoEvento = 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.Numero = _numero and contrato.RutCliente = _rutCliente and contrato.IdModalidad = _idModalidad;
            SET respuesta = 1;
            
		when _numero = "" and _rutCliente <> "" and _idModalidad <> "" and _idTipoEvento <> 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.IdTipoEvento = _idTipoEvento and contrato.RutCliente = _rutCliente and contrato.IdModalidad = _idModalidad;
            SET respuesta = 1;
            
		when _numero <> "" and _rutCliente = "" and _idModalidad <> "" and _idTipoEvento <> 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.IdTipoEvento = _idTipoEvento and contrato.Numero = _numero and contrato.IdModalidad = _idModalidad;
            SET respuesta = 1;
            
		when _numero <> "" and _rutCliente <> "" and _idModalidad = "" and _idTipoEvento <> 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.IdTipoEvento = _idTipoEvento and contrato.Numero = _numero and contrato.RutCliente = _rutCliente;
            SET respuesta = 1;
            
		when _numero <> "" and _rutCliente <> "" and _idModalidad <> "" and _idTipoEvento <> 0 THEN
			SELECT contrato.Numero, contrato.Creacion, contrato.Termino, contrato.RutCliente, cliente.NombreContacto, modalidadservicio.Nombre, tipoevento.Descripcion, contrato.FechaHoraInicio,
            contrato.FechaHoraTermino, contrato.Asistentes, contrato.PersonalAdicional, contrato.Realizado, contrato.ValorTotalContrato, contrato.Observaciones from contrato left join  cliente on contrato.RutCliente = cliente.RutCliente 
            left join  modalidadservicio on contrato.IdModalidad = modalidadservicio.IdModalidad left join tipoevento on contrato.IdTipoEvento = tipoevento.IdTipoEvento where contrato.IdTipoEvento = _idTipoEvento and contrato.Numero = _numero and contrato.RutCliente = _rutCliente and contrato.IdModalidad = _idModalidad;
            SET respuesta = 1;
		ELSE SET respuesta = 0;
    end case;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getModServicio` (`_tipoevento` INT)  BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message; 
	
    IF _tipoevento <> 0 THEN
    	SELECT modalidadservicio.IdModalidad, modalidadservicio.Nombre, modalidadservicio.ValorBase, modalidadservicio.PersonalBase, modalidadservicio.IdTipoEvento FROM modalidadservicio WHERE modalidadservicio.IdTipoEvento = _tipoevento;
    ELSE SELECT modalidadservicio.IdModalidad, modalidadservicio.Nombre, modalidadservicio.ValorBase, modalidadservicio.PersonalBase, modalidadservicio.IdTipoEvento FROM modalidadservicio;
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `gettabla` (`_rutCliente` VARCHAR(10), `_idTipoEmpresa` INT, `_idActividadEmpresa` INT)  BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message; 
	CASE 
    	WHEN _rutCliente = '' AND _idActividadEmpresa=0 AND _idTipoEmpresa=0 
        	THEN SELECT RutCliente, Direccion, MailContacto,NombreContacto,RazonSocial, Telefono, actividadempresa.Descripcion "Actividad", tipoempresa.Descripcion "Tipo Empresa" FROM cliente LEFT JOIN actividadempresa ON 
            		cliente.IdActividadEmpresa = actividadempresa.IdActividadEmpresa LEFT JOIN tipoempresa ON cliente.IdTipoEmpresa = tipoempresa.IdTipoEmpresa;
                    
        WHEN _rutCliente <> '' AND _idActividadEmpresa=0 AND _idTipoEmpresa=0 
        	THEN SELECT RutCliente, Direccion, MailContacto,NombreContacto,RazonSocial, Telefono, actividadempresa.Descripcion "Actividad", tipoempresa.Descripcion "Tipo Empresa" FROM cliente LEFT JOIN actividadempresa ON 
            		cliente.IdActividadEmpresa = actividadempresa.IdActividadEmpresa LEFT JOIN tipoempresa ON cliente.IdTipoEmpresa = tipoempresa.IdTipoEmpresa WHERE cliente.RutCliente = _rutCliente;
                    
        WHEN _rutCliente = '' AND _idActividadEmpresa<>0 AND _idTipoEmpresa=0 
        	THEN SELECT RutCliente, Direccion, MailContacto,NombreContacto,RazonSocial, Telefono, actividadempresa.Descripcion "Actividad", tipoempresa.Descripcion "Tipo Empresa" FROM cliente LEFT JOIN actividadempresa ON 
            		cliente.IdActividadEmpresa = actividadempresa.IdActividadEmpresa LEFT JOIN tipoempresa ON cliente.IdTipoEmpresa = tipoempresa.IdTipoEmpresa WHERE actividadempresa.IdActividadEmpresa = _idActividadEmpresa;
                    
        WHEN _rutCliente = '' AND _idActividadEmpresa=0 AND _idTipoEmpresa<>0 
        	THEN SELECT RutCliente, Direccion, MailContacto,NombreContacto,RazonSocial, Telefono, actividadempresa.Descripcion "Actividad", tipoempresa.Descripcion "Tipo Empresa" FROM cliente LEFT JOIN actividadempresa ON 
            		cliente.IdActividadEmpresa = actividadempresa.IdActividadEmpresa LEFT JOIN tipoempresa ON cliente.IdTipoEmpresa = tipoempresa.IdTipoEmpresa WHERE tipoempresa.IdTipoEmpresa = _idTipoEmpresa;
                    
		WHEN _rutCliente <> '' AND _idActividadEmpresa<>0 AND _idTipoEmpresa=0 
        	THEN SELECT RutCliente, Direccion, MailContacto,NombreContacto,RazonSocial, Telefono, actividadempresa.Descripcion "Actividad", tipoempresa.Descripcion "Tipo Empresa" FROM cliente LEFT JOIN actividadempresa ON 
            		cliente.IdActividadEmpresa = actividadempresa.IdActividadEmpresa LEFT JOIN tipoempresa ON cliente.IdTipoEmpresa = tipoempresa.IdTipoEmpresa WHERE actividadempresa.IdActividadEmpresa = _idActividadEmpresa AND
                    cliente.RutCliente = _rutCliente;
        
        WHEN _rutCliente <> '' AND _idActividadEmpresa=0 AND _idTipoEmpresa<>0 
        	THEN SELECT RutCliente, Direccion, MailContacto,NombreContacto,RazonSocial, Telefono, actividadempresa.Descripcion "Actividad", tipoempresa.Descripcion "Tipo Empresa" FROM cliente LEFT JOIN actividadempresa ON 
            		cliente.IdActividadEmpresa = actividadempresa.IdActividadEmpresa LEFT JOIN tipoempresa ON cliente.IdTipoEmpresa = tipoempresa.IdTipoEmpresa WHERE tipoempresa.IdTipoEmpresa = _idTipoEmpresa AND
                    cliente.RutCliente = _rutCliente;
                    
        WHEN _rutCliente = '' AND _idActividadEmpresa<>0 AND _idTipoEmpresa<>0 
        	THEN SELECT RutCliente, Direccion, MailContacto,NombreContacto,RazonSocial, Telefono, actividadempresa.Descripcion "Actividad", tipoempresa.Descripcion "Tipo Empresa" FROM cliente LEFT JOIN actividadempresa ON 
            		cliente.IdActividadEmpresa = actividadempresa.IdActividadEmpresa LEFT JOIN tipoempresa ON cliente.IdTipoEmpresa = tipoempresa.IdTipoEmpresa WHERE tipoempresa.IdTipoEmpresa = _idTipoEmpresa AND
                    actividadempresa.IdActividadEmpresa = _idActividadEmpresa;
                    
		WHEN _rutCliente <> '' AND _idActividadEmpresa<>0 AND _idTipoEmpresa<>0 
        	THEN SELECT RutCliente, Direccion, MailContacto,NombreContacto,RazonSocial, Telefono, actividadempresa.Descripcion "Actividad", tipoempresa.Descripcion "Tipo Empresa" FROM cliente LEFT JOIN actividadempresa ON 
            		cliente.IdActividadEmpresa = actividadempresa.IdActividadEmpresa LEFT JOIN tipoempresa ON cliente.IdTipoEmpresa = tipoempresa.IdTipoEmpresa WHERE tipoempresa.IdTipoEmpresa = _idTipoEmpresa AND
                    actividadempresa.IdActividadEmpresa = _idActividadEmpresa AND cliente.RutCliente = _rutCliente;
    END CASE;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `getTipoEvento` (`_tipoevento` INT)  BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message; 
	
    IF _tipoevento <> 0 THEN
    	SELECT tipoevento.IdTipoEvento, tipoevento.Descripcion FROM tipoevento WHERE tipoevento.IdTipoEvento = _tipoevento;
    ELSE SELECT tipoevento.IdTipoEvento, tipoevento.Descripcion FROM tipoevento;
    END IF;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertCliente` (`_Direccion` VARCHAR(30), `_IdActividadEmpresa` INT, `_IdTipoEmpresa` INT, `_MailContacto` VARCHAR(30), `_NombreContacto` VARCHAR(50), `_RazonSocial` VARCHAR(50), `_RutCliente` VARCHAR(10), `_Telefono` VARCHAR(15), OUT `ingresado` INT)  BEGIN
	DECLARE EXIT HANDLER FOR 1062 SET ingresado = 0; 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message;
	INSERT INTO cliente(Direccion,IdActividadEmpresa,IdTipoEmpresa,MailContacto,NombreContacto,RazonSocial,RutCliente,Telefono)
            		VALUES(_Direccion,_IdActividadEmpresa,_IdTipoEmpresa,_MailContacto,_NombreContacto,_RazonSocial,_RutCliente,_Telefono);
    SET ingresado = 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `InsertContratos` (`_Numero` VARCHAR(12), `_Creacion` DATETIME, `_RutCliente` VARCHAR(10), `_IdModalidad` VARCHAR(5), `_IdTipoEvento` INT, `_FechaHoraInicio` DATETIME, `_FechaHoraTermino` DATETIME, `_Asistentes` INT, `_PersonalAdicional` INT, `_Realizado` BIT, `_ValorTotalContrato` FLOAT, `_Observaciones` VARCHAR(250), OUT `ingresado` INT)  BEGIN
	DECLARE EXIT HANDLER FOR 1062 SET ingresado = 0; 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message;
	INSERT INTO `contrato`(`Numero`, `Creacion`, `RutCliente`, `IdModalidad`, `IdTipoEvento`, `FechaHoraInicio`, `FechaHoraTermino`, `Asistentes`, `PersonalAdicional`, `Realizado`, `ValorTotalContrato`, `Observaciones`) VALUES (_Numero, _Creacion, _RutCliente, _IdModalidad, _IdTipoEvento, _FechaHoraInicio, _FechaHoraTermino, _Asistentes, _PersonalAdicional, _Realizado, _ValorTotalContrato, _Observaciones);
    SET ingresado = 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `TerminoContrato` (`_Numero` VARCHAR(12), `_termino` DATETIME, OUT `ingresado` INT)  BEGIN
	DECLARE EXIT HANDLER FOR 1062 SET ingresado = 0; 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message;
	UPDATE contrato SET contrato.Termino = _termino WHERE contrato.Numero = _Numero ;
    SET ingresado = 1;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `TipoEmpresa` ()  BEGIN
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message; 
	SELECT tipoempresa.IdTipoEmpresa "ID", tipoempresa.Descripcion FROM tipoempresa;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `updateCliente` (`_Direccion` VARCHAR(30), `_IdActividadEmpresa` INT, `_IdTipoEmpresa` INT, `_MailContacto` VARCHAR(30), `_NombreContacto` VARCHAR(50), `_RazonSocial` VARCHAR(50), `_RutCliente` VARCHAR(10), `_Telefono` VARCHAR(15), OUT `respuesta` INT)  BEGIN
	DECLARE clienteExist int;
    DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message; 
    SELECT COUNT(RutCliente) INTO clienteExist FROM cliente WHERE RutCliente = _RutCliente;
                CASE clienteExist
                	WHEN 0 THEN 
                    	SET respuesta = 0;
                	ELSE UPDATE cliente SET cliente.Direccion=_Direccion , cliente.IdActividadEmpresa=_IdActividadEmpresa, cliente.IdTipoEmpresa=_IdTipoEmpresa, cliente.MailContacto=_MailContacto, cliente.NombreContacto=_NombreContacto, cliente.RazonSocial=_RazonSocial, cliente.RutCliente =_RutCliente, cliente.Telefono = _Telefono WHERE cliente.RutCliente = _RutCliente;
                    SET respuesta =1;
                END CASE;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `UpdateContrato` (`_Numero` VARCHAR(12), `_IdModalidad` VARCHAR(5), `_IdTipoEvento` INT, `_FechaHoraInicio` DATETIME, `_FechaHoraTermino` DATETIME, `_Asistentes` INT, `_PersonalAdicional` INT, `_Realizado` BIT, `_ValorTotalContrato` FLOAT, `_Observaciones` VARCHAR(250), OUT `ingresado` INT)  BEGIN
	DECLARE EXIT HANDLER FOR 1062 SET ingresado = 0; 
	DECLARE EXIT HANDLER FOR SQLEXCEPTION SELECT 'SQLException encountered' Message;
	UPDATE contrato SET contrato.IdModalidad = _IdModalidad,
    contrato.IdTipoEvento = _IdTipoEvento,
    contrato.FechaHoraInicio = _FechaHoraInicio,
    contrato.FechaHoraTermino = _FechaHoraTermino,
    contrato.Asistentes = _Asistentes,
    contrato.PersonalAdicional = _PersonalAdicional,
    contrato.Realizado = _Realizado,
    contrato.ValorTotalContrato = _ValorTotalContrato,
    contrato.Observaciones = _Observaciones
    WHERE contrato.Numero = _Numero ;
    SET ingresado = 1;
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `actividadempresa`
--

CREATE TABLE `actividadempresa` (
  `IdActividadEmpresa` int(11) NOT NULL,
  `Descripcion` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `actividadempresa`
--

INSERT INTO `actividadempresa` (`IdActividadEmpresa`, `Descripcion`) VALUES
(1, 'Agropecuaria'),
(2, 'Minería'),
(3, 'Manufactura'),
(4, 'Comercio'),
(5, 'Hotelería'),
(6, 'Alimentos'),
(7, 'Transporte'),
(8, 'Servicios');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `cliente`
--

CREATE TABLE `cliente` (
  `RutCliente` varchar(10) NOT NULL,
  `RazonSocial` varchar(50) NOT NULL,
  `NombreContacto` varchar(50) NOT NULL,
  `MailContacto` varchar(30) NOT NULL,
  `Direccion` varchar(30) NOT NULL,
  `Telefono` varchar(15) NOT NULL,
  `IdActividadEmpresa` int(11) NOT NULL,
  `IdTipoEmpresa` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `cliente`
--

INSERT INTO `cliente` (`RutCliente`, `RazonSocial`, `NombreContacto`, `MailContacto`, `Direccion`, `Telefono`, `IdActividadEmpresa`, `IdTipoEmpresa`) VALUES
('0000000-0', 'PRUEBA', 'PRUEBA', 'PRUEBA', 'PRUEBA', 'PRUEBA', 1, 10),
('1111111-1', 'PRUEBA1', 'PRUEBA1', 'PRUEBA1', 'PRUEBA1', 'PRUEBA1', 2, 20),
('2222222-2', 'PRUEBA2', 'PRUEBA2', 'PRUEBA2', 'PRUEBA2', 'PRUEBA2', 1, 10),
('3333333-3', 'renato4', 'Renato Reyes', 'renato2', 'renato1', 'renato3', 7, 40),
('8888888-8', 'empresa', 'Renato Reyes', 're@g.com', 'Santiago', '789456123', 6, 20);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `contrato`
--

CREATE TABLE `contrato` (
  `Numero` varchar(12) NOT NULL,
  `Creacion` datetime NOT NULL,
  `Termino` datetime DEFAULT '3000-12-31 00:00:00',
  `RutCliente` varchar(10) NOT NULL,
  `IdModalidad` varchar(5) NOT NULL,
  `IdTipoEvento` int(11) NOT NULL,
  `FechaHoraInicio` datetime NOT NULL,
  `FechaHoraTermino` datetime NOT NULL,
  `Asistentes` int(11) NOT NULL,
  `PersonalAdicional` int(11) NOT NULL,
  `Realizado` bit(1) NOT NULL,
  `ValorTotalContrato` float NOT NULL,
  `Observaciones` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `contrato`
--

INSERT INTO `contrato` (`Numero`, `Creacion`, `Termino`, `RutCliente`, `IdModalidad`, `IdTipoEvento`, `FechaHoraInicio`, `FechaHoraTermino`, `Asistentes`, `PersonalAdicional`, `Realizado`, `ValorTotalContrato`, `Observaciones`) VALUES
('202006232135', '2020-06-23 21:35:29', '2020-06-24 16:48:26', '2222222-2', 'CO001', 20, '2020-07-01 21:34:18', '2020-07-05 21:34:21', 100, 2, b'0', 18, 'gsgf'),
('202006241658', '2020-06-24 16:58:16', '2020-06-24 18:13:04', '8888888-8', 'CE001', 30, '2020-06-10 22:24:48', '2020-06-12 22:24:48', 20, 30, b'1', 44.5, 'nuvvvvvv');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `modalidadservicio`
--

CREATE TABLE `modalidadservicio` (
  `IdModalidad` varchar(5) NOT NULL,
  `IdTipoEvento` int(11) NOT NULL,
  `Nombre` varchar(20) NOT NULL,
  `ValorBase` float NOT NULL,
  `PersonalBase` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `modalidadservicio`
--

INSERT INTO `modalidadservicio` (`IdModalidad`, `IdTipoEvento`, `Nombre`, `ValorBase`, `PersonalBase`) VALUES
('CB001', 10, 'Light Break', 3, 2),
('CB002', 10, 'Journal Break', 8, 6),
('CB003', 10, 'Day Break', 12, 6),
('CE001', 30, 'Ejecutiva', 25, 10),
('CE002', 30, 'Celebración', 35, 14),
('CO001', 20, 'Quick Cocktail', 6, 4),
('CO002', 20, 'Ambient Cocktail', 10, 5);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipoempresa`
--

CREATE TABLE `tipoempresa` (
  `IdTipoEmpresa` int(11) NOT NULL,
  `Descripcion` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tipoempresa`
--

INSERT INTO `tipoempresa` (`IdTipoEmpresa`, `Descripcion`) VALUES
(10, 'SPA'),
(20, 'EIRL'),
(30, 'Limitada'),
(40, 'Sociedad Anónima');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `tipoevento`
--

CREATE TABLE `tipoevento` (
  `IdTipoEvento` int(11) NOT NULL,
  `Descripcion` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Volcado de datos para la tabla `tipoevento`
--

INSERT INTO `tipoevento` (`IdTipoEvento`, `Descripcion`) VALUES
(10, 'Coffee Break'),
(20, 'Cocktail'),
(30, 'Cenas');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `actividadempresa`
--
ALTER TABLE `actividadempresa`
  ADD PRIMARY KEY (`IdActividadEmpresa`);

--
-- Indices de la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD PRIMARY KEY (`RutCliente`),
  ADD KEY `Cliente_ActividadEmpresa_FK1` (`IdActividadEmpresa`),
  ADD KEY `Cliente_TipoEmpresa_FK1` (`IdTipoEmpresa`);

--
-- Indices de la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD PRIMARY KEY (`Numero`),
  ADD KEY `Contrato_Cliente_FK1` (`RutCliente`),
  ADD KEY `Contrato_ModalidadEvento_FK1` (`IdModalidad`),
  ADD KEY `Contrato_ModalidadEvento_FK2` (`IdTipoEvento`);

--
-- Indices de la tabla `modalidadservicio`
--
ALTER TABLE `modalidadservicio`
  ADD PRIMARY KEY (`IdModalidad`),
  ADD KEY `ModalidadServicio_TipoEvento_FK1` (`IdTipoEvento`);

--
-- Indices de la tabla `tipoempresa`
--
ALTER TABLE `tipoempresa`
  ADD PRIMARY KEY (`IdTipoEmpresa`);

--
-- Indices de la tabla `tipoevento`
--
ALTER TABLE `tipoevento`
  ADD PRIMARY KEY (`IdTipoEvento`);

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `cliente`
--
ALTER TABLE `cliente`
  ADD CONSTRAINT `Cliente_ActividadEmpresa_FK1` FOREIGN KEY (`IdActividadEmpresa`) REFERENCES `actividadempresa` (`IdActividadEmpresa`),
  ADD CONSTRAINT `Cliente_TipoEmpresa_FK1` FOREIGN KEY (`IdTipoEmpresa`) REFERENCES `tipoempresa` (`IdTipoEmpresa`);

--
-- Filtros para la tabla `contrato`
--
ALTER TABLE `contrato`
  ADD CONSTRAINT `Contrato_Cliente_FK1` FOREIGN KEY (`RutCliente`) REFERENCES `cliente` (`RutCliente`),
  ADD CONSTRAINT `Contrato_ModalidadEvento_FK1` FOREIGN KEY (`IdModalidad`) REFERENCES `modalidadservicio` (`IdModalidad`),
  ADD CONSTRAINT `Contrato_ModalidadEvento_FK2` FOREIGN KEY (`IdTipoEvento`) REFERENCES `modalidadservicio` (`IdTipoEvento`);

--
-- Filtros para la tabla `modalidadservicio`
--
ALTER TABLE `modalidadservicio`
  ADD CONSTRAINT `ModalidadServicio_TipoEvento_FK1` FOREIGN KEY (`IdTipoEvento`) REFERENCES `tipoevento` (`IdTipoEvento`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
