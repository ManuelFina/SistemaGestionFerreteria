CREATE PROCEDURE SP_LISTAR_VENTAS
AS
BEGIN
    SELECT
        V.Id AS VentaId,
        C.Nombre AS Cliente,
        V.Fecha,
        V.Total
    FROM Ventas V
    INNER JOIN Clientes C
        ON V.ClienteId = C.Id
END