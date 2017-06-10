 public class PrivacyPolicyService : BaseService, IPrivacyPolicy
        
        public int Insert(PrivacyPolicyAddRequest model) 
        {
            int id = 0; 

            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PrivacyPolicy_Insert" 
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                   paramCollection.AddWithValue("@ParentId", model.ParentId);
                   paramCollection.AddWithValue("@Title", model.Title);
                   paramCollection.AddWithValue("@Description", model.Description);
                   paramCollection.AddWithValue("@DisplayOrder", model.DisplayOrder);
                   paramCollection.AddWithValue("@CreatedBy", model.CreatedBy);   

                   SqlParameter p = new SqlParameter("@Id", System.Data.SqlDbType.Int); 
                   p.Direction = System.Data.ParameterDirection.Output;

                   paramCollection.Add(p);

               }, returnParameters: delegate (SqlParameterCollection param)
               {
                   int.TryParse(param["@Id"].Value.ToString(), out id); 
               }
               );
            return id;
        }

        public List<PrivacyPolicy> Get() 
        {
            List<PrivacyPolicy> list = null; 

            DataProvider.ExecuteCmd(GetConnection, "dbo.PrivacyPolicy_Select"
               , inputParamMapper: null 
               , map: delegate (IDataReader reader, short set)
               {
                   PrivacyPolicy p = new PrivacyPolicy();
                   int startingIndex = 0; 

                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.ParentId = reader.GetSafeInt32(startingIndex++);
                   p.Title = reader.GetSafeString(startingIndex++);
                   p.Description = reader.GetSafeString(startingIndex++);
                   p.DisplayOrder = reader.GetSafeInt32(startingIndex++);
                   p.CreatedBy = reader.GetSafeString(startingIndex++);
                   p.CreatedDate = reader.GetSafeDateTime(startingIndex++);
                   p.ModifiedBy = reader.GetSafeString(startingIndex++);
                   p.ModifiedDate = reader.GetSafeDateTime(startingIndex++);

                   if (list == null)
                   {
                       list = new List<PrivacyPolicy>();
                   }

                   list.Add(p);
               }
               );

            return list;
        }

        public void Update(PrivacyPolicyUpdateRequest model) 
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PrivacyPolicy_Update"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@ParentId", model.ParentId);
                    paramCollection.AddWithValue("@Title", model.Title);
                    paramCollection.AddWithValue("@Description", model.Description);
                    paramCollection.AddWithValue("@DisplayOrder", model.DisplayOrder);
                    paramCollection.AddWithValue("@ModifiedBy", model.ModifiedBy);
                    paramCollection.AddWithValue("@Id", model.Id); 
                }
                );
        }

        public PrivacyPolicy Get(int id) 
        {
            PrivacyPolicy p = new PrivacyPolicy();
            DataProvider.ExecuteCmd(GetConnection, "dbo.PrivacyPolicy_SelectById"
               , inputParamMapper: delegate (SqlParameterCollection paramCollection)
               {
                 
                   paramCollection.AddWithValue("@Id", id); 

               }, map: delegate (IDataReader reader, short set)
               {
                   
                   int startingIndex = 0; 
                   p.Id = reader.GetSafeInt32(startingIndex++);
                   p.ParentId = reader.GetSafeInt32(startingIndex++); 
                   p.DisplayOrder = reader.GetSafeInt32(startingIndex++);

                   p.Title = reader.GetSafeString(startingIndex++);
                   p.Description = reader.GetSafeString(startingIndex++);
                   p.CreatedBy = reader.GetString(startingIndex++);
                   p.CreatedDate = reader.GetSafeDateTime(startingIndex++);
                   p.ModifiedBy = reader.GetString(startingIndex++);
                   p.ModifiedDate = reader.GetDateTime(startingIndex++);
				   
               }      
               );
                return p;
        }

        public void Delete(int id) 
        {
            DataProvider.ExecuteNonQuery(GetConnection, "dbo.PrivacyPolicy_Delete"
                , inputParamMapper: delegate (SqlParameterCollection paramCollection)
                {
                    paramCollection.AddWithValue("@Id", id);
                }
                , returnParameters: null

                );


        }

    }