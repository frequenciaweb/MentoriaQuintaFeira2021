using MentoriaQuintaFeira2021.Domain.Entities;
using System.Linq;

namespace MentoriaQuintaFeira2021.Infra.Data.EF
{
    public static class SEED
    {
        public static void Populate(EFContext context)
        {
            if (context.Produtos.Count() == 0)
            {
                context.Produtos.AddRange(
                    new Produto { ID = 1, Categoria = "BEBIDAS", Descricao = "COCA COLA", Quantidade = 100, Valor = 3.50M },
                    new Produto { ID = 2, Categoria = "BEBIDAS", Descricao = "CERVEJA", Quantidade = 100, Valor = 7.50M },
                    new Produto { ID = 3, Categoria = "BEBIDAS", Descricao = "VINHO", Quantidade = 100, Valor = 13.50M },
                    new Produto { ID = 4, Categoria = "BEBIDAS", Descricao = "CACHAÇA", Quantidade = 100, Valor = 1.50M },
                    new Produto { ID = 5, Categoria = "BISCOITO", Descricao = "PASSATEMPO", Quantidade = 100, Valor = 3.50M },
                    new Produto { ID = 6, Categoria = "BISCOITO", Descricao = "BONO", Quantidade = 100, Valor = 3.50M },
                    new Produto { ID = 7, Categoria = "LANCHES", Descricao = "PIZZA", Quantidade = 100, Valor = 2.50M },
                    new Produto { ID = 8, Categoria = "LANCHES", Descricao = "COXINHA", Quantidade = 100, Valor = 1.00M }
                    );
            }

            if (context.Clientes.Count() == 0)
            {
                context.Clientes.AddRange(
                        new Cliente
                        {
                            ID = 1,
                            Nome = "JOSE DA SILVA",
                            Endereco = new Domain.VO.VOEndereco
                            {
                                Bairro = "TESTE BAIRRO",
                                CEP = "00000000",
                                Cidade = "TESTE CIDADE",
                                Logradouro = "TESTE LOGRADOURO",
                                Numero = "",
                                UF = "DF"
                            }
                        },
                        new Cliente
                        {
                            ID = 2,
                            Nome = "MARIA APARECIDA",
                            Endereco = new Domain.VO.VOEndereco
                            {
                                Bairro = "TESTE BAIRRO",
                                CEP = "00000000",
                                Cidade = "TESTE CIDADE",
                                Logradouro = "TESTE LOGRADOURO",
                                Numero = "",
                                UF = "DF"
                            }
                        },
                        new Cliente
                        {
                            ID = 3,
                            Nome = "CARLOS ANDRE",
                            Endereco = new Domain.VO.VOEndereco
                            {
                                Bairro = "TESTE BAIRRO",
                                CEP = "00000000",
                                Cidade = "TESTE CIDADE",
                                Logradouro = "TESTE LOGRADOURO",
                                Numero = "",
                                UF = "DF"
                            }
                        },
                        new Cliente
                        {
                            ID = 4,
                            Nome = "PAULO VELOSO",
                            Endereco = new Domain.VO.VOEndereco
                            {
                                Bairro = "TESTE BAIRRO",
                                CEP = "00000000",
                                Cidade = "TESTE CIDADE",
                                Logradouro = "TESTE LOGRADOURO",
                                Numero = "",
                                UF = "DF"
                            }
                        },
                        new Cliente
                        {
                            ID = 5,
                            Nome = "SERGIO CABRAL",
                            Endereco = new Domain.VO.VOEndereco
                            {
                                Bairro = "TESTE BAIRRO",
                                CEP = "00000000",
                                Cidade = "TESTE CIDADE",
                                Logradouro = "TESTE LOGRADOURO",
                                Numero = "",
                                UF = "DF"
                            }
                        }
                    );

                context.SaveChanges();
            }
        }
    }
}
