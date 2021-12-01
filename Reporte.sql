/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     01/12/2021 11:00:57                          */
/*==============================================================*/

USE Registro
GO
if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('ALM_ALUMNO') and o.name = 'FK_ALM_ALUM_RELATIONS_GRD_GRAD')
alter table ALM_ALUMNO
   drop constraint FK_ALM_ALUM_RELATIONS_GRD_GRAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MXG_MATERIASXGRADO') and o.name = 'FK_MXG_MATE_RELATIONS_GRD_GRAD')
alter table MXG_MATERIASXGRADO
   drop constraint FK_MXG_MATE_RELATIONS_GRD_GRAD
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MXG_MATERIASXGRADO') and o.name = 'FK_MXG_MATE_RELATIONS_MAT_MATE')
alter table MXG_MATERIASXGRADO
   drop constraint FK_MXG_MATE_RELATIONS_MAT_MATE
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('ALM_ALUMNO')
            and   name  = 'RELATIONSHIP_3_FK'
            and   indid > 0
            and   indid < 255)
   drop index ALM_ALUMNO.RELATIONSHIP_3_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('ALM_ALUMNO')
            and   type = 'U')
   drop table ALM_ALUMNO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('GRD_GRADO')
            and   type = 'U')
   drop table GRD_GRADO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MAT_MATERIA')
            and   type = 'U')
   drop table MAT_MATERIA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MXG_MATERIASXGRADO')
            and   name  = 'RELATIONSHIP_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index MXG_MATERIASXGRADO.RELATIONSHIP_2_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('MXG_MATERIASXGRADO')
            and   name  = 'RELATIONSHIP_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index MXG_MATERIASXGRADO.RELATIONSHIP_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MXG_MATERIASXGRADO')
            and   type = 'U')
   drop table MXG_MATERIASXGRADO
go

/*==============================================================*/
/* Table: ALM_ALUMNO                                            */
/*==============================================================*/
create table ALM_ALUMNO (
   ALM_ID               int                  identity,
   ALM_ID_GRD           int                  null,
   ALM_CODIGO           char(100)            not null,
   ALM_NOMBRE           char(300)            not null,
   ALM_EDAD             int                  not null,
   ALM_SEXO             char(100)            not null,
   ALM_OBSERVACION      char(300)            not null,
   constraint PK_ALM_ALUMNO primary key nonclustered (ALM_ID)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_3_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_3_FK on ALM_ALUMNO (
ALM_ID_GRD ASC
)
go

/*==============================================================*/
/* Table: GRD_GRADO                                             */
/*==============================================================*/
create table GRD_GRADO (
   GRD_ID               int                  identity,
   GRD_NOMBRE           char(100)            not null,
   constraint PK_GRD_GRADO primary key nonclustered (GRD_ID)
)
go

/*==============================================================*/
/* Table: MAT_MATERIA                                           */
/*==============================================================*/
create table MAT_MATERIA (
   MAT_ID               int                  identity,
   MAT_NOMBRE           char(100)            not null,
   constraint PK_MAT_MATERIA primary key nonclustered (MAT_ID)
)
go

/*==============================================================*/
/* Table: MXG_MATERIASXGRADO                                    */
/*==============================================================*/
create table MXG_MATERIASXGRADO (
   GRD_ID               int                  null,
   MAT_ID               int                  null,
   MXG_ID               int                  identity,
   constraint PK_MXG_MATERIASXGRADO primary key (MXG_ID)
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_1_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_1_FK on MXG_MATERIASXGRADO (
GRD_ID ASC
)
go

/*==============================================================*/
/* Index: RELATIONSHIP_2_FK                                     */
/*==============================================================*/
create index RELATIONSHIP_2_FK on MXG_MATERIASXGRADO (
MAT_ID ASC
)
go

alter table ALM_ALUMNO
   add constraint FK_ALM_ALUM_RELATIONS_GRD_GRAD foreign key (ALM_ID_GRD)
      references GRD_GRADO (GRD_ID)
go

alter table MXG_MATERIASXGRADO
   add constraint FK_MXG_MATE_RELATIONS_GRD_GRAD foreign key (GRD_ID)
      references GRD_GRADO (GRD_ID)
go

alter table MXG_MATERIASXGRADO
   add constraint FK_MXG_MATE_RELATIONS_MAT_MATE foreign key (MAT_ID)
      references MAT_MATERIA (MAT_ID)
go

