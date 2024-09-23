using NS.Core.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NS.Core.Models
{
    public partial class DataSeeding
    {
        public static void SeedPhuongthucDayHoc(AppDbContext dbContext)
        {
            if(!dbContext.CaiDatTongThe.Where(record=> record.TrangId==3).Any())
            {
                dbContext.CaiDatTongThe.Add(GenerateConfigForPhuongthucDayHoc());
                dbContext.SaveChanges();
            }
        }

        private static CaiDatTongThe GenerateConfigForPhuongthucDayHoc()
        {
            var res = new CaiDatTongThe
            {
                CaiDatChiTiet = new List<CaiDatChiTiet>{
                            new CaiDatChiTiet
                            {
                                TieuDe= "Tổ Chức",
                                TieuDeTiengAnh= "organization",
                                MoTa= "<p>Tổ chức dạy học và quản lí bán trú từ lớp 1 đến lớp 5,<Br/> GVCN là “người mẹ thứ hai”, truyền dạy kiến thức và tư vấn, chăm sóc học sinh 2 buổi/ngày.</p>",
                                MoTaTiengAnh= "<p>Tổ chức dạy học và quản lí bán trú từ lớp 1 đến lớp 5,<Br/> GVCN là “người mẹ thứ hai”, truyền dạy kiến thức và tư vấn, chăm sóc học sinh 2 buổi/ngày.",
                                Link= "",
                                Icon= "",
                                LinkAnh= "https://randomuser.me/api/portraits/men/75.jpg",
                            },
                             new CaiDatChiTiet
                            {
                                TieuDe= "Lớp Học",
                                TieuDeTiengAnh= "Class Room",
                                MoTa= "<p>Lớp học có sĩ số thấp (<=30HS/lớp) để GV có điều kiện dạy học nhóm, quan tâm chăm sóc HS theo quan điểm “không bỏ rơi học sinh nào”.</p>",
                                MoTaTiengAnh= "<p>Lớp học có sĩ số thấp (<=30HS/lớp) để GV có điều kiện dạy học nhóm, quan tâm chăm sóc HS theo quan điểm “không bỏ rơi học sinh nào”.</p>",
                                Link= "",
                                Icon= "",
                                LinkAnh= "https://randomuser.me/api/portraits/men/75.jpg",
                            },
                             new CaiDatChiTiet
                            {
                                TieuDe= "Chương Trình Học",
                                TieuDeTiengAnh= "Chương Trình Học",
                                MoTa= "<p><strong>Chương trình học</strong> đa mục tiêu, phát triển dạy học song ngữ, hình thức tổ chức dạy học hiện đại, phong phú: phân hoá theo trình độ, dạy học tích hợp, dạy học ngoài trời, trải nghiệm, thực hành tại phòng thí nghiệm đạt chuẩn quốc tế, đẩy mạnh giao lưu hợp tác, ứng dụng CNTT, giáo dục kĩ năng sống theo 08 giá trị cốt lõi của Trường.</p>",
                                MoTaTiengAnh= "<p><strong>Chương trình học</strong> đa mục tiêu, phát triển dạy học song ngữ, hình thức tổ chức dạy học hiện đại, phong phú: phân hoá theo trình độ, dạy học tích hợp, dạy học ngoài trời, trải nghiệm, thực hành tại phòng thí nghiệm đạt chuẩn quốc tế, đẩy mạnh giao lưu hợp tác, ứng dụng CNTT, giáo dục kĩ năng sống theo 08 giá trị cốt lõi của Trường.</p>",
                                Link= "",
                                Icon= "",
                                LinkAnh= "https://randomuser.me/api/portraits/men/75.jpg",
                            },
                        },
                TieuDe = "Phương Thức dạy hoc",
                TieuDeTiengAnh = "Phương Thức dạy học English",
                Mota = "",
                MotaTiengAnh = "The LastName, FirstName, Address, and City columns are of type varchar and will hold characters, and the maximum length for these fields is 255 characters.",
                Link = "",
                TrangId=3,
            };
            return res;
        }
    }
}
