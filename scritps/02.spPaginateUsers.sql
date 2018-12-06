CREATE PROC [dbo].[usp_GetAllPaginate](@PageIndex int, @PageSize int)  
AS  
BEGIN  
SELECT * FROM Usuarios ORDER BY Id OFFSET((@PageIndex-1)*@PageSize) ROWS  
FETCH NEXT @PageSize ROWS ONLY;  
END  
GO 