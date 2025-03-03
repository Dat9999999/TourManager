-------------------------------------
Cấu Trúc Thư Mục Dự Án:

TourManagement/
│── Data/                    # Làm việc với cơ sở dữ liệu
│   │── DatabaseContext.cs    
│   │── DbInitializer.cs      
│── Models/                  # Chứa các model đại diện cho DB
│   │── Tour.cs              
│   │── Customer.cs          
│   │── Booking.cs           
│   │── Employee.cs          
│── Repositories/            # Xử lý dữ liệu với DB
│   │── ITourRepository.cs   
│   │── TourRepository.cs    
│── Services/                # Chứa logic nghiệp vụ
│   │── TourService.cs       
│   │── BookingService.cs    
│── Forms/                   # Giao diện ứng dụng
│   │── MainForm.cs          
│   │── Tour/ #chứa các form chức năng liên quan đến tour
│   │── Booking/ #chứa các form chức năng liên quan đến Đặt vé    
│   │── Customer/ #chứa các form chức năng liên quan đến Khách hàng   
│   │── report/ #chứa các form chức năng liên quan đến Báo cáo
│   │── Schedule/ #chứa các form chức năng liên quan đến Lịch trình
│── Utils/                   # Các hàm hỗ trợ chung
│   │── Helper.cs            
│   │── Constants.cs         
│── Program.cs               # Điểm vào chính của ứng dụng
│── appsetting.json        # File cấu hình
