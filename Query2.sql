/* - Listar os primeiros 4 clientes que tenham alguma parcela com mais de 05 dias atrasadas 
(Data Vencimento maior que data atual E data pagamento nula) */

SELECT TOP 4 Nome, Parcelas FROM (select cli.Nome,
SUM(CASE WHEN par.DataPagamento IS NULL and par.DataVencimento < GETDATE() THEN 1 ELSE 0 END) as Parcelas From Cliente cli 
JOIN Financiamento fin on cli.Id = fin.IdCliente 
JOIN Parcela par on fin.Id = par.IdFinanciamento Group by cli.Nome) as Total
order by Parcelas desc

