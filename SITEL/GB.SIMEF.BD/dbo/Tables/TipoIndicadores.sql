﻿CREATE TABLE [dbo].[TipoIndicadores] (
    [IdTipoIdicador] INT           NOT NULL,
    [Nombre]         VARCHAR (350) NOT NULL,
    [Estado]         BIT           CONSTRAINT [DF_TipoIndicadores_Estado] DEFAULT ((1)) NOT NULL,
    CONSTRAINT [PK_TipoIndicadores] PRIMARY KEY CLUSTERED ([IdTipoIdicador] ASC)
);


