using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.ModelBinding;


namespace Livraria.Servico.Utilitario
{

    public class ModelStateUtil
    {
        //método para retornar as mensagens de erro
        //de validação geradas pelas classes model..
        public static Hashtable GetValidationMessages(ModelStateDictionary state)
        {
            Hashtable erros = new Hashtable();

            //percorrer o modelstate..
            foreach (var s in state)
            {

                string[] k = s.Key.Split(new char(), '.');

                if (k.Length == 1)
                {
                    if(state.Count == 1)
                    {
                        string chave = "Erro";
                        erros[chave] = "Erro na formatação do arquivo JSON.";
                    }                                                     
                }
                else
                {
                    if (s.Value.Errors.Count > 0)
                    {                  
                        string chave = s.Key.Split('.')[1];
                        erros[chave] = s.Value.Errors.Select(e => e.ErrorMessage).ToList();
                    }
                }
                
            }

            return erros;
        }
    }

    //public class ModelStateUtil
    //{
    //    //método para retornar as mensagens de erro
    //    //de validação geradas pelas classes model..
    //    public static Hashtable GetValidationMessages(ModelStateDictionary state)
    //    {
    //        Hashtable erros = new Hashtable();

    //        //percorrer o modelstate..
    //        foreach (var s in state)
    //        {             
    //            if (s.Value.Errors.Count > 0)
    //            {
    //                //armazenando os erros do campo especificado dentro do HashTable                    
    //                string chave = s.Key.Split('.')[1];
    //                erros[chave] = s.Value.Errors.Select(e => e.ErrorMessage).ToList();                                        
    //            }
    //        }

    //        return erros;
    //    }
    //}
}