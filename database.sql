CREATE DATABASE gestao_facil_bd;
USE gestao_facil_bd;

CREATE TABLE campus (
	id_cam INT NOT NULL AUTO_INCREMENT,
    nome_cam VARCHAR(255) NOT NULL,
    PRIMARY KEY (id_cam)
);

DROP TABLE IF EXISTS servidor;
CREATE TABLE servidor (
	id_ser INT NOT NULL AUTO_INCREMENT,
    nome_ser VARCHAR(255) NOT NULL,
    cpf_ser VARCHAR(14) NOT NULL,
    siape_ser INT NOT NULL,
    id_cam_fk INT NOT NULL,
    PRIMARY KEY(id_ser),
    FOREIGN KEY(id_cam_fk) REFERENCES campus (id_cam)
);

INSERT INTO campus VALUES 
	(null, "IFRO Ji-Paraná"),
    (null, "IFRO Cacoal"),
    (null, "IFRO Vilhena");
    
INSERT INTO servidor VALUES 
	(null, "João Teixeira", "123.123.123-33", 4467721, 1),
    (null, "Reinaldo Lima", "546.342.453-23", 4467722, 2),
    (null, "Emi de Oliveira", "234.234.652.42", 3245674, 3),
    (null, "Jefferson Antonio", "321.443.721-00", 3245675, 1);
    
SELECT * FROM servidor, campus WHERE id_cam_fk = id_cam;
SELECT * FROM servidor;
SELECT * FROM campus;

