using DTOs;

namespace WebMVC.Models
{
    public class AltaMovimientoStockViewModel
    {
        public IEnumerable<ArticuloDTO> ArticuloDTOs = new List<ArticuloDTO>();
        public IEnumerable<TipoMovimientoDTO> TiposMovimientoDTO {  get; set; }
        public int ArticuloId { get; set; }
        public int TipoMovimientoId { get; set; }
        public int Cantidad {  get; set; }
        public string EmailUsuario { get; set; }
        
    }
}
