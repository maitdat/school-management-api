﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NS.Core.Models.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDatabaseV128 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                insert into CaiDatTongThe (TrangId) values (9)
                declare @caiDatTongTheId int
                select @caiDatTongTheId = max(id) from CaiDatTongThe
                
                insert into CaiDatChiTiet (CaiDatTongTheId, MoTa, Icon) values
                (@caiDatTongTheId
                , N'Học sinh vi phạm nội quy sẽ bị xử lí kỷ luật theo điều lệ trường có nhiều cấp học của Bộ Giáo dục và Đào tạo và theo quy định trong Sổ tay\r\n          học sinh của Nhà trường.'
                , N'<svg xmlns=""http://www.w3.org/2000/svg"" width=""28"" height=""26"" viewBox=""0 0 28 26"" fill=""none"">\r\n  <path d=""M13.5844 3.61016C13.6719 3.4625 13.8305 3.375 14 3.375C14.1695 3.375 14.3281 3.4625 14.4156 3.61016L25.2602 21.4219C25.3367 21.5477 25.375 21.6898 25.375 21.832C25.375 22.2695 25.0195 22.625 24.582 22.625H3.41797C2.98047 22.625 2.625 22.2695 2.625 21.832C2.625 21.6844 2.66328 21.5422 2.73984 21.4219L13.5844 3.61016ZM11.3422 2.24297L0.497656 20.0547C0.169531 20.5906 0 21.2031 0 21.832C0 23.7188 1.53125 25.25 3.41797 25.25H24.582C26.4688 25.25 28 23.7188 28 21.832C28 21.2031 27.825 20.5906 27.5023 20.0547L16.6578 2.24297C16.0945 1.31875 15.0883 0.75 14 0.75C12.9117 0.75 11.9055 1.31875 11.3422 2.24297ZM15.75 19.125C15.75 18.6609 15.5656 18.2158 15.2374 17.8876C14.9092 17.5594 14.4641 17.375 14 17.375C13.5359 17.375 13.0908 17.5594 12.7626 17.8876C12.4344 18.2158 12.25 18.6609 12.25 19.125C12.25 19.5891 12.4344 20.0342 12.7626 20.3624C13.0908 20.6906 13.5359 20.875 14 20.875C14.4641 20.875 14.9092 20.6906 15.2374 20.3624C15.5656 20.0342 15.75 19.5891 15.75 19.125ZM15.3125 9.0625C15.3125 8.33516 14.7273 7.75 14 7.75C13.2727 7.75 12.6875 8.33516 12.6875 9.0625V14.3125C12.6875 15.0398 13.2727 15.625 14 15.625C14.7273 15.625 15.3125 15.0398 15.3125 14.3125V9.0625Z"" fill=""#F05A22""/>\r\n</svg>'),
                (@caiDatTongTheId
                , N'Mọi ý kiến phản ánh, đóng góp, cha mẹ học sinh có thể liên hệ trực\r\n          tiếp qua các kênh thông tin sau (vào giờ hành chính các ngày làm việc\r\n trong tuần):'
                , null),
                (@caiDatTongTheId
                , '02437844889'
                , N'<svg xmlns=""http://www.w3.org/2000/svg"" width=""20"" height=""20"" viewBox=""0 0 20 20"" fill=""none"">\r\n  <g clip-path=""url(#clip0_518_7099)"">\r\n    <path d=""M14.6771 10.7477C14.0366 10.4743 13.2946 10.654 12.8532 11.1929L11.5566 12.7786C9.76003 11.7358 8.26029 10.2361 7.2175 8.4395L8.79926 7.14676C9.33823 6.70543 9.52179 5.96337 9.24449 5.32286L7.36982 0.948615C7.0769 0.261234 6.33875 -0.121512 5.6084 0.0347108L1.23416 0.972048C0.515536 1.12437 0 1.76097 0 2.49913C0 11.7436 7.16673 19.3126 16.2472 19.9531C16.4229 19.9648 16.6026 19.9766 16.7822 19.9844C16.7822 19.9844 16.7822 19.9844 16.7862 19.9844C17.0244 19.9922 17.2587 20 17.5009 20C18.239 20 18.8756 19.4845 19.028 18.7658L19.9653 14.3916C20.1215 13.6613 19.7388 12.9231 19.0514 12.6302L14.6771 10.7555V10.7477ZM17.4853 18.7463C8.51805 18.7385 1.24978 11.4702 1.24978 2.49913C1.24978 2.35072 1.35133 2.22574 1.49583 2.19449L5.87008 1.25716C6.01458 1.22591 6.16299 1.30402 6.22158 1.44072L8.09625 5.81496C8.15093 5.94384 8.11578 6.09225 8.00642 6.17818L6.42076 7.47483C5.94819 7.86148 5.82321 8.53714 6.13175 9.0683C7.28389 11.0562 8.93986 12.7122 10.9239 13.8604C11.455 14.169 12.1307 14.044 12.5174 13.5714L13.814 11.9858C13.9038 11.8764 14.0523 11.8413 14.1772 11.8959L18.5515 13.7706C18.6882 13.8292 18.7663 13.9776 18.735 14.1221L17.7977 18.4964C17.7665 18.6409 17.6376 18.7424 17.4931 18.7424C17.4892 18.7424 17.4853 18.7424 17.4813 18.7424L17.4853 18.7463Z"" fill=""#F05A22""/>\r\n  </g>\r\n  <defs>\r\n    <clipPath id=""clip0_518_7099"">\r\n      <rect width=""20"" height=""20"" fill=""white""/>\r\n    </clipPath>\r\n  </defs>\r\n</svg>'),
                (@caiDatTongTheId
                , 'Info@thnguyensieu.edu.vn'
                , N'<svg xmlns=""http://www.w3.org/2000/svg"" width=""20"" height=""20"" viewBox=""0 0 20 20"" fill=""none"">\r\n  <path d=""M2.5 3.75C1.80859 3.75 1.25 4.30859 1.25 5V6.55859L8.89062 12.1602C9.55078 12.6445 10.4492 12.6445 11.1094 12.1602L18.75 6.55859V5C18.75 4.30859 18.1914 3.75 17.5 3.75H2.5ZM1.25 8.10938V15C1.25 15.6914 1.80859 16.25 2.5 16.25H17.5C18.1914 16.25 18.75 15.6914 18.75 15V8.10938L11.8477 13.168C10.7461 13.9727 9.25 13.9727 8.15234 13.168L1.25 8.10938ZM0 5C0 3.62109 1.12109 2.5 2.5 2.5H17.5C18.8789 2.5 20 3.62109 20 5V15C20 16.3789 18.8789 17.5 17.5 17.5H2.5C1.12109 17.5 0 16.3789 0 15V5Z"" fill=""#F05A22""/>\r\n</svg>')
            ");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

