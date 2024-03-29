USE [vente]
GO
/****** Object:  Table [dbo].[Categorie]    Script Date: 1/5/2023 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorie](
	[id_cat] [int] IDENTITY(1,1) NOT NULL,
	[nom_cat] [nvarchar](50) NULL,
	[id_dep] [int] NULL,
 CONSTRAINT [PK_Categorie] PRIMARY KEY CLUSTERED 
(
	[id_cat] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Client]    Script Date: 1/5/2023 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Client](
	[id_client] [int] IDENTITY(1,1) NOT NULL,
	[nom] [nvarchar](50) NULL,
	[prenom] [nvarchar](50) NULL,
	[tel] [nvarchar](50) NULL,
	[adress] [nvarchar](max) NULL,
 CONSTRAINT [PK_Client] PRIMARY KEY CLUSTERED 
(
	[id_client] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Commande]    Script Date: 1/5/2023 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commande](
	[num_commande] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[etat] [nvarchar](50) NULL,
	[id_client] [int] NULL,
	[ref_prod] [nvarchar](50) NULL,
 CONSTRAINT [PK_Commande] PRIMARY KEY CLUSTERED 
(
	[num_commande] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Departement]    Script Date: 1/5/2023 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Departement](
	[id_dep] [int] IDENTITY(1,1) NOT NULL,
	[nom_dep] [nvarchar](50) NULL,
 CONSTRAINT [PK_Departement] PRIMARY KEY CLUSTERED 
(
	[id_dep] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Facture]    Script Date: 1/5/2023 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Facture](
	[num_fac] [int] IDENTITY(1,1) NOT NULL,
	[date] [date] NULL,
	[num_commande] [int] NULL,
 CONSTRAINT [PK_Facture] PRIMARY KEY CLUSTERED 
(
	[num_fac] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ligne_Commande]    Script Date: 1/5/2023 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ligne_Commande](
	[num_commande] [int] NOT NULL,
	[ref_prod] [nvarchar](50) NOT NULL,
	[qte] [int] NULL,
 CONSTRAINT [PK_Ligne_Commande] PRIMARY KEY CLUSTERED 
(
	[ref_prod] ASC,
	[num_commande] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Produit]    Script Date: 1/5/2023 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Produit](
	[ref_prod] [nvarchar](50) NOT NULL,
	[libelle] [nvarchar](50) NULL,
	[prix] [numeric](18, 4) NULL,
	[qte] [int] NULL,
	[id_cat] [int] NULL,
 CONSTRAINT [PK_Produit] PRIMARY KEY CLUSTERED 
(
	[ref_prod] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Utilisateur]    Script Date: 1/5/2023 1:54:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Utilisateur](
	[id_user] [int] IDENTITY(1,1) NOT NULL,
	[nom] [nvarchar](50) NULL,
	[prenom] [nvarchar](50) NULL,
	[tel] [nvarchar](50) NULL,
 CONSTRAINT [PK_Utilisateur] PRIMARY KEY CLUSTERED 
(
	[id_user] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categorie]  WITH CHECK ADD  CONSTRAINT [FK_Categorie_Departement] FOREIGN KEY([id_dep])
REFERENCES [dbo].[Departement] ([id_dep])
GO
ALTER TABLE [dbo].[Categorie] CHECK CONSTRAINT [FK_Categorie_Departement]
GO
ALTER TABLE [dbo].[Commande]  WITH CHECK ADD  CONSTRAINT [FK_Commande_Client] FOREIGN KEY([id_client])
REFERENCES [dbo].[Client] ([id_client])
GO
ALTER TABLE [dbo].[Commande] CHECK CONSTRAINT [FK_Commande_Client]
GO
ALTER TABLE [dbo].[Facture]  WITH CHECK ADD  CONSTRAINT [FK_Facture_Commande] FOREIGN KEY([num_commande])
REFERENCES [dbo].[Commande] ([num_commande])
GO
ALTER TABLE [dbo].[Facture] CHECK CONSTRAINT [FK_Facture_Commande]
GO
ALTER TABLE [dbo].[Ligne_Commande]  WITH CHECK ADD  CONSTRAINT [FK_Ligne_Commande_Commande] FOREIGN KEY([num_commande])
REFERENCES [dbo].[Commande] ([num_commande])
GO
ALTER TABLE [dbo].[Ligne_Commande] CHECK CONSTRAINT [FK_Ligne_Commande_Commande]
GO
ALTER TABLE [dbo].[Ligne_Commande]  WITH CHECK ADD  CONSTRAINT [FK_Ligne_Commande_Produit] FOREIGN KEY([ref_prod])
REFERENCES [dbo].[Produit] ([ref_prod])
GO
ALTER TABLE [dbo].[Ligne_Commande] CHECK CONSTRAINT [FK_Ligne_Commande_Produit]
GO
ALTER TABLE [dbo].[Produit]  WITH CHECK ADD  CONSTRAINT [FK_Produit_Categorie] FOREIGN KEY([id_cat])
REFERENCES [dbo].[Categorie] ([id_cat])
GO
ALTER TABLE [dbo].[Produit] CHECK CONSTRAINT [FK_Produit_Categorie]
GO
