CREATE DATABASE  IF NOT EXISTS `db_solucion` /*!40100 DEFAULT CHARACTER SET latin1 */;
USE `db_solucion`;
-- MySQL dump 10.13  Distrib 8.0.20, for Win64 (x86_64)
--
-- Host: localhost    Database: db_solucion
-- ------------------------------------------------------
-- Server version	5.7.30-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `so_empleados`
--

DROP TABLE IF EXISTS `so_empleados`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `so_empleados` (
  `e_idEmpleado` int(11) NOT NULL AUTO_INCREMENT,
  `e_nombre` varchar(45) DEFAULT NULL,
  `e_apellido` varchar(45) DEFAULT NULL,
  `e_fechaNacimiento` date DEFAULT NULL,
  PRIMARY KEY (`e_idEmpleado`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `so_empleados`
--

LOCK TABLES `so_empleados` WRITE;
/*!40000 ALTER TABLE `so_empleados` DISABLE KEYS */;
INSERT INTO `so_empleados` VALUES (1,'ottoniel','barillas','2020-05-10');
/*!40000 ALTER TABLE `so_empleados` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `so_menu`
--

DROP TABLE IF EXISTS `so_menu`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `so_menu` (
  `m_idMenu` int(11) NOT NULL AUTO_INCREMENT,
  `m_titulo` varchar(50) DEFAULT NULL,
  `m_url` varchar(50) DEFAULT NULL,
  `m_idPadre` int(11) DEFAULT NULL,
  `m_descripcion` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`m_idMenu`)
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `so_menu`
--

LOCK TABLES `so_menu` WRITE;
/*!40000 ALTER TABLE `so_menu` DISABLE KEYS */;
INSERT INTO `so_menu` VALUES (1,'Empleados','javascript:;',0,'Empleados'),(2,'Listado','~/Vistas/Empleados.aspx',1,NULL),(3,'Clientes','~/Vistas/Clientes.aspx',1,NULL),(4,'Departamentos','Empleados.aspx',1,NULL),(5,'Lectura','javascript:;',0,'Lectura'),(6,'Ingreso','Ingreso.aspx',5,NULL),(7,'Ingreso','Ingreso.aspx',6,NULL),(8,'Lectrua2','Vistas/Lectura.aspx',7,'Lectura2');
/*!40000 ALTER TABLE `so_menu` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `so_usuario`
--

DROP TABLE IF EXISTS `so_usuario`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `so_usuario` (
  `u_idUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `u_usuario` varchar(45) DEFAULT NULL,
  `u_contrasenia` varchar(45) DEFAULT NULL,
  `u_habilitado` int(11) DEFAULT NULL,
  `u_idEmpleado` int(11) NOT NULL,
  `u_correlativo` int(11) DEFAULT NULL,
  PRIMARY KEY (`u_idUsuario`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `so_usuario`
--

LOCK TABLES `so_usuario` WRITE;
/*!40000 ALTER TABLE `so_usuario` DISABLE KEYS */;
INSERT INTO `so_usuario` VALUES (2,'admin','admin',1,1,1),(3,'obarillasvc','c2sd8Z3SpOz4g0a9gVUF4A==',1,1,2),(4,'obarillas','032lj9JAfyxw0SMosHRtVw==',1,0,3);
/*!40000 ALTER TABLE `so_usuario` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'db_solucion'
--

--
-- Dumping routines for database 'db_solucion'
--
/*!50003 DROP PROCEDURE IF EXISTS `sp_iniciarSession` */;
/*!50003 SET @saved_cs_client      = @@character_set_client */ ;
/*!50003 SET @saved_cs_results     = @@character_set_results */ ;
/*!50003 SET @saved_col_connection = @@collation_connection */ ;
/*!50003 SET character_set_client  = utf8mb4 */ ;
/*!50003 SET character_set_results = utf8mb4 */ ;
/*!50003 SET collation_connection  = utf8mb4_general_ci */ ;
/*!50003 SET @saved_sql_mode       = @@sql_mode */ ;
/*!50003 SET sql_mode              = 'STRICT_TRANS_TABLES,NO_AUTO_CREATE_USER,NO_ENGINE_SUBSTITUTION' */ ;
DELIMITER ;;
CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_iniciarSession`(
vidUsuario int,
vUsuario varchar(12), 
vContrasenia varchar(50),
vidEmpleado int,
vOpcion int
)
BEGIN
IF (vOpcion = 1) THEN 
	select u_usuario
    from so_usuario 
    where u_usuario = vUsuario 
    and u_contrasenia = vContrasenia  
    and  u_habilitado = 1; 
END IF;

IF(vOpcion = 2)THEN 
	INSERT INTO so_usuario(`u_usuario`, `u_contrasenia`, `u_habilitado`,u_idEmpleado) 
    VALUES (vUsuario, vContrasenia, '1' ,vidEmpleado);
    select last_insert_id() mensaje;
END IF;

IF(vOpcion = 3)THEN 
	SELECT e_idEmpleado, upper( concat(e_nombre, ' ', e_apellido)) nombre  FROM so_empleados;
END IF;
IF(vOpcion = 4) THEN 
	SELECT 
	u_correlativo, u_usuario, concat(e_nombre, ' ', e_apellido) nombre  FROM so_usuario 
	inner join so_empleados  on e_idEmpleado = u_idEmpleado
;

END IF;
END ;;
DELIMITER ;
/*!50003 SET sql_mode              = @saved_sql_mode */ ;
/*!50003 SET character_set_client  = @saved_cs_client */ ;
/*!50003 SET character_set_results = @saved_cs_results */ ;
/*!50003 SET collation_connection  = @saved_col_connection */ ;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-11 22:45:28
