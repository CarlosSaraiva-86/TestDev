/* - Listar todos os clientes que já atrasaram em algum momento duas ou mais parcelas em mais de 10 dias, 
e que o valor do financiamento seja maior que R$ 10.000,00. */


SELECT Nome, Parcelas FROM (select cli.Nome,
SUM(CASE WHEN par.DataPagamento > DATEADD(DD,10,par.DataVencimento) THEN 1 ELSE 0 END) as Parcelas From Cliente cli 
JOIN Financiamento fin on cli.Id = fin.IdCliente 
JOIN Parcela par on fin.Id = par.IdFinanciamento where fin.ValorTotal > 10000
group by cli.Nome) as Total
where Parcelas > 2
