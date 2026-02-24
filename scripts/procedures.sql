-- Stored Procedure (PL/pgSQL): Buscar cargas por período
-- O candidato deve implementar o CargoQueryRepository usando Dapper para chamar esta função.

CREATE OR REPLACE FUNCTION buscar_cargas_por_periodo(
    data_inicio TIMESTAMP,
    data_fim TIMESTAMP
)
RETURNS TABLE (
    id INTEGER,
    numero VARCHAR(50),
    tipo VARCHAR(30),
    peso DECIMAL(10, 2),
    origem VARCHAR(100),
    destino VARCHAR(100),
    status VARCHAR(20),
    data_registro TIMESTAMP,
    total_containers BIGINT
) AS $$
BEGIN
    RETURN QUERY
    SELECT
        c.id,
        c.numero,
        c.tipo,
        c.peso,
        c.origem,
        c.destino,
        c.status,
        c.data_registro,
        COUNT(ct.id) AS total_containers
    FROM cargos c
    LEFT JOIN containers ct ON ct.cargo_id = c.id
    WHERE c.data_registro BETWEEN data_inicio AND data_fim
    GROUP BY c.id, c.numero, c.tipo, c.peso, c.origem, c.destino, c.status, c.data_registro
    ORDER BY c.data_registro DESC;
END;
$$ LANGUAGE plpgsql;
