SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetBySearch
	@search nvarchar(max)=null
AS
BEGIN
	SELECT * FROM [dbo].[Tbl_Product] P
	LEFT JOIN [dbo].[Tbl_Category] C ON P.CategoryId = C.CategoryId
	WHERE P.ProductName LIKE CASE WHEN @search IS NOT NULL THEN  '%' + @search + '%' ELSE P.ProductName END
	OR C.CategoryName LIKE CASE WHEN @search IS NOT NULL THEN  '%' + @search + '%' ELSE C.CategoryName END
END
GO
