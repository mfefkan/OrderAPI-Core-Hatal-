using OrderAPI.DTO;

namespace OrderAPI.APIResponseModels
{
    public class ApiResponse
    {
        public List<ProductDTO> Products { get; set; }

    }

    
}
public enum Status
{
    Success,
    Failed
}