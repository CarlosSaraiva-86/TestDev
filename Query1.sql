/*- Listar todos os clientes do estado de SP que tenham mais de 60% das parcelas pagas. */


SELECT Nome, TotalParcelas, SemPgto, PorcentagemPago
FROM (select cli.Nome, SUM(CASE WHEN par.DataPagamento IS NULL THEN 1 ELSE 0 END) as SemPgto, Count(par.Id) as TotalParcelas,
((ROUND(((CAST(SUM(CASE WHEN par.DataPagamento IS NULL THEN 1 ELSE 0 END) AS DECIMAL)*100)/(CAST(Count(par.Id) AS DECIMAL))),2) - 100) * -1) as PorcentagemPago
from Cliente cli 
JOIN Financiamento fin on cli.Id = fin.IdCliente 
JOIN Parcela par on fin.Id = par.IdFinanciamento Where cli.UF = 'SP' group by cli.Id, cli.Nome) as Total
Where PorcentagemPago > 60

