-- Dados de exemplo para o sistema de gestão de cargas

-- Cargas
INSERT INTO cargos (numero, tipo, peso, origem, destino, status, data_registro) VALUES
('CRG-2024-001', 'Container', 15000.50, 'Porto de Santos', 'Porto de Roterdã', 'Liberada', '2024-01-15 08:30:00'),
('CRG-2024-002', 'Granel', 45000.00, 'Porto de Paranaguá', 'Porto de Xangai', 'Em Trânsito', '2024-01-20 14:00:00'),
('CRG-2024-003', 'Líquido', 28000.75, 'Porto de Suape', 'Porto de Houston', 'No Porto', '2024-02-01 10:15:00'),
('CRG-2024-004', 'Carga Geral', 8500.00, 'Porto de Itajaí', 'Porto de Buenos Aires', 'Pendente', '2024-02-10 09:00:00'),
('CRG-2024-005', 'Container', 22000.30, 'Porto de Santos', 'Porto de Antuérpia', 'Em Trânsito', '2024-02-15 16:45:00'),
('CRG-2024-006', 'Granel', 55000.00, 'Porto de Rio Grande', 'Porto de Hamburgo', 'Liberada', '2024-03-01 07:00:00'),
('CRG-2024-007', 'Container', 18500.00, 'Porto de Vitória', 'Porto de Singapura', 'Retida', '2024-03-05 11:30:00'),
('CRG-2024-008', 'Líquido', 32000.00, 'Porto de São Luís', 'Porto de Mumbai', 'No Porto', '2024-03-10 13:20:00'),
('CRG-2024-009', 'Carga Geral', 12000.00, 'Porto de Belém', 'Porto de Lisboa', 'Pendente', '2024-03-15 08:00:00'),
('CRG-2024-010', 'Container', 27500.80, 'Porto de Santos', 'Porto de Yokohama', 'Em Trânsito', '2024-03-20 15:00:00'),
('CRG-2024-011', 'Granel', 60000.00, 'Porto de Paranaguá', 'Porto de Busan', 'Liberada', '2024-04-01 06:30:00'),
('CRG-2024-012', 'Container', 19800.00, 'Porto de Itajaí', 'Porto de Valparaíso', 'No Porto', '2024-04-05 10:00:00'),
('CRG-2024-013', 'Líquido', 35000.50, 'Porto de Suape', 'Porto de Jeddah', 'Em Trânsito', '2024-04-10 14:30:00'),
('CRG-2024-014', 'Carga Geral', 9200.00, 'Porto de Salvador', 'Porto de Durban', 'Pendente', '2024-04-15 09:45:00'),
('CRG-2024-015', 'Container', 21000.00, 'Porto de Santos', 'Porto de Felixstowe', 'Retida', '2024-04-20 12:00:00');

-- Containers
INSERT INTO containers (codigo, cargo_id, tamanho, conteudo, lacrado) VALUES
('MSKU1234567', 1, '40ft', 'Peças automotivas', true),
('MSKU1234568', 1, '20ft', 'Componentes eletrônicos', true),
('MSKU2345678', 5, '40ft HC', 'Máquinas industriais', true),
('MSKU2345679', 5, '40ft', 'Equipamentos médicos', false),
('MSKU2345680', 5, '20ft', 'Ferramentas', true),
('MSKU3456789', 7, '40ft', 'Produtos químicos embalados', true),
('MSKU3456790', 7, '40ft HC', 'Materiais de construção', true),
('MSKU4567890', 10, '20ft', 'Têxteis', true),
('MSKU4567891', 10, '40ft', 'Calçados', true),
('MSKU4567892', 10, '40ft', 'Acessórios de moda', false),
('MSKU4567893', 10, '20ft', 'Brinquedos', true),
('MSKU5678901', 12, '40ft HC', 'Vinhos e bebidas', true),
('MSKU5678902', 12, '20ft', 'Alimentos não perecíveis', true),
('MSKU6789012', 15, '40ft', 'Papel e celulose', true),
('MSKU6789013', 15, '40ft', 'Madeira processada', false);

-- Manifests
INSERT INTO manifests (cargo_id, numero, data_emissao, despachante, observacoes) VALUES
(1, 'MAN-2024-001', '2024-01-14 16:00:00', 'João Silva - Despachos Ltda', 'Documentação completa. Carga liberada para embarque.'),
(2, 'MAN-2024-002', '2024-01-19 11:00:00', 'Maria Santos - Global Trade', 'Carga de soja a granel. Inspeção fitossanitária aprovada.'),
(3, 'MAN-2024-003', '2024-01-31 09:00:00', 'Carlos Oliveira - Port Services', 'Óleo combustível. Requer certificado de segurança IMDG.'),
(5, 'MAN-2024-004', '2024-02-14 14:00:00', 'Ana Costa - Express Cargo', NULL),
(6, 'MAN-2024-005', '2024-02-28 08:00:00', 'Pedro Almeida - Sul Despachos', 'Minério de ferro. Peso conferido e dentro do limite.'),
(7, 'MAN-2024-006', '2024-03-04 10:00:00', 'Luísa Ferreira - Nordeste Trade', 'Carga retida para inspeção adicional da Receita Federal.'),
(10, 'MAN-2024-007', '2024-03-19 13:00:00', 'Ricardo Mendes - Asia Pacific Logistics', 'Múltiplos containers. Verificar lacres antes do embarque.'),
(11, 'MAN-2024-008', '2024-03-31 07:00:00', 'Fernanda Lima - Grain Export Co', 'Carga de milho. Certificado de origem emitido.'),
(13, 'MAN-2024-009', '2024-04-09 15:00:00', 'Marcos Pereira - Petro Logistics', 'Derivados de petróleo. Documentação IMO classe 3.');
