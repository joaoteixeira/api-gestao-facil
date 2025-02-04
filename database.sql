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

CREATE TABLE funcao (
    id_fun INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
    nome_fun VARCHAR(255) NOT NULL
);

INSERT INTO funcao VALUES 
	(null, "Docente"),
    (null, "Coordenador");

CREATE TABLE servidor_funcao (
    servidor_id INTEGER NOT NULL,
    funcao_id INTEGER NOT NULL,
    PRIMARY KEY (servidor_id, funcao_id),
    FOREIGN KEY (servidor_id) REFERENCES servidor (id_ser) ON DELETE CASCADE,
    FOREIGN KEY (funcao_id) REFERENCES funcao (id_fun) ON DELETE CASCADE);

INSERT INTO servidor_funcao VALUES 
	(1, 1),
    (1, 2),
    (2, 1),
    (3, 2);

SELECT * FROM servidor, campus WHERE id_cam_fk = id_cam;
SELECT * FROM servidor;
SELECT * FROM campus;

SELECT * FROM servidor S
    LEFT JOIN servidor_funcao SF ON SF.servidor_id = S.id_ser
    LEFT JOIN funcao F ON F.id_fun = SF.funcao_id;

