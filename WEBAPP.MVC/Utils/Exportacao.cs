using Newtonsoft.Json;
using OfficeOpenXml;
using OfficeOpenXml.Style;

namespace WEBAPP.MVC.Utils
{
    public static class Exportacao
    {
        public static ExcelPackage Export(List<object> lista)
        {
            using (ExcelPackage ep = new())
            {
                // Propriedades do arquivo
                ep.Workbook.Properties.Author = "Vinicius";
                ep.Workbook.Properties.Title = "Export";
                ep.Workbook.Properties.Subject = "Estudo de implementação da biblioteca EPP Plus";
                ep.Workbook.Properties.Created = DateTime.Now;
                ep.Workbook.Date1904 = true;

                // Criação das planilhas
                ExcelWorksheet planilha = ep.Workbook.Worksheets.Add("Primeira Planilha");
                
                // Personalização
                planilha.Rows.Style.Font.Bold = true; 
                planilha.Column(2).Width = 55; 
                planilha.Row(1).Height = 55; 
                         
                // Proteção da planilha
                planilha.Protection.IsProtected = false; // Protege toda a planilha
                planilha.Protection.AllowInsertColumns = true; // Permite criar colunas
                planilha.Protection.SetPassword("seila"); // Atribui password para a proteção
                planilha.Protection.AllowSelectLockedCells = false; // Permissão de selecionar celulas bloqueadas
                planilha.Cells.Style.Locked = true;  // bloqueia as celulas
                planilha.Cells.Style.Hidden = true; // Oculta o conteudo da celula*/

                // Criando uma tabela
                planilha.Tables.Add(planilha.Cells["A1:D4"], "novatabela");
                planilha.Tables[0].ShowFilter = false;
                planilha.Tables[0].TableStyle = OfficeOpenXml.Table.TableStyles.Dark7;
                planilha.Tables[0].TableBorderStyle.BorderAround(ExcelBorderStyle.Dotted);

                // Criação do cabeçario da tabela
                string json = JsonConvert.SerializeObject(lista[0]);
                var values = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                int coluna = 0;
                foreach (var atributo in values)
                {
                    planilha.Tables[0].Columns[coluna].Name = atributo.Key;
                    coluna++;
                }

                // Inclusão de valores nas celulas
                for(int i = 0; i < lista.Count; i++)
                { 
                    var jsonDado = JsonConvert.SerializeObject(lista[i]);
                    var valueDado = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                    int linha = i + 2;
                    int col = 0;

                    foreach (var valor in valueDado)
                    {
                        planilha.Cells[linha, col].Value = valueDado.Values;
                        col++;
                    }
                }

                return ep;
            }
        }

    }
}
