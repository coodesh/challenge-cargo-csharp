-- DDL: Criação das tabelas do sistema de gestão de cargas portuárias

CREATE TABLE IF NOT EXISTS cargos (
    id SERIAL PRIMARY KEY,
    numero VARCHAR(50) NOT NULL UNIQUE,
    tipo VARCHAR(30) NOT NULL CHECK (tipo IN ('Granel', 'Container', 'Carga Geral', 'Líquido')),
    peso DECIMAL(10, 2) NOT NULL CHECK (peso > 0),
    origem VARCHAR(100) NOT NULL,
    destino VARCHAR(100) NOT NULL,
    status VARCHAR(20) NOT NULL DEFAULT 'Pendente' CHECK (status IN ('Pendente', 'Em Trânsito', 'No Porto', 'Liberada', 'Retida')),
    data_registro TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP
);

CREATE TABLE IF NOT EXISTS containers (
    id SERIAL PRIMARY KEY,
    codigo VARCHAR(20) NOT NULL UNIQUE,
    cargo_id INTEGER NOT NULL REFERENCES cargos(id) ON DELETE CASCADE,
    tamanho VARCHAR(10) NOT NULL CHECK (tamanho IN ('20ft', '40ft', '40ft HC')),
    conteudo VARCHAR(200) NOT NULL,
    lacrado BOOLEAN NOT NULL DEFAULT true
);

CREATE TABLE IF NOT EXISTS manifests (
    id SERIAL PRIMARY KEY,
    cargo_id INTEGER NOT NULL REFERENCES cargos(id) ON DELETE CASCADE,
    numero VARCHAR(50) NOT NULL UNIQUE,
    data_emissao TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    despachante VARCHAR(100) NOT NULL,
    observacoes VARCHAR(500)
);

-- Índices para consultas frequentes
CREATE INDEX IF NOT EXISTS idx_cargos_status ON cargos(status);
CREATE INDEX IF NOT EXISTS idx_cargos_data_registro ON cargos(data_registro);
CREATE INDEX IF NOT EXISTS idx_containers_cargo_id ON containers(cargo_id);
CREATE INDEX IF NOT EXISTS idx_manifests_cargo_id ON manifests(cargo_id);
