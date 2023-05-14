namespace Common.Api
{
    public static class Messages
    {
        public enum TypeAlarm
        {
            Success,
            Danger,
            Info,
            Warning
        }

        #region External Properties

        public static string ValidPicExt => "jpg, jpeg, png";

        public static string ValidVideoExt => "mp4,mov,webm,mkv,flv,avi,3gp";

        public static string ValidAnimatedPicExt => "jpg, bmp, png , gif, ico";

        public static string ValidDocExt => "pdf";

        public static string ValidZipExt => "rar, zip";

        public static string ValidFileExt => "pdf, jpg, jpeg, png, gif, flv, zip, rar";

        #endregion External Properties

        #region Properties

        public enum MessageType
        {
            VerifyConfirmed,
            VerifyRejected,
            SuccessSent,
            ErrorSameExist,
            ErrorNotFoundItem,
            ErrorFailedCount,
            ErrorInValidate,
            ErrorUnSecurePassword,
            ErrorRegister,
            ErrorLogin,
            ErrorLoginAccessFailed,
            ErrorUserInActive,
            SuccessCall,
            SuccessUpload,
            SuccessUploadAuthenticationFile,
            AllFieldsRequired,
            StarFieldsRequired,
            PassNotEqualToRepass,
            SuccessRegister,
            SuccessInsert, SuccessUpdate, SuccessDelete, SuccessAccept, SuccessDecline, SuccessPending,
            NotAccessAdmin, NotAccessUser,
            ErrorInSystem, ErrorInInsert, ErrorInUpdate, ErrorInDelete, ErrorInInsertOrUpdate, ErrorInDeleteOrUpdate, ErrorInInputParameter,
            ErrorInValidInputData,
            ErrorInTypingData,
            ErrorTypingDataIsOutOfRanges,
            ErrorInImageResizer,
            ErrorInMailSender,
            ErrorInGettingData,
            ErrorChooseVideo,
            ErrorChoosePic,
            ErrorChooseDoc,
            ErrorChooseZip,
            ErrorInvalidAnimatedPicExt,
            ErrorInvalidFile,
            ErrorInvalidFileExt,
            ErrorInvalidPicExt,
            ErrorInvalidDocExt,
            ErrorInvalidZipExt,
            ErrorInvalidVideoExt,
            ErrorInPicLen,
            ErrorInVideoLen,
            ErrorInFileLen,
            ErrorOutputIsEmpty,
            ErrorInSearch,
            NewsLetterSended,
            ErrorInRss,
            ErrorInDeleteOrSet,
            SuccessSetGalleryCover,
            SuccessRefresh,
            ErrorInRefresh,
            ErrorNoCity,
            ErrorNoCountry,
            ErrorEmptyBasket,
            ErrorNotAcceptPayToGetCard,
            ErrorEndCapacity,
            ErrorHaveChild,
            ErrorCityHaveMember,
            ErrorInputOneTBox,
            ErrorOldPassword,
            ErrorCantDelete,
            ErrorDeleteSubset,
            ErrorDeleteOrActive,
            ErrorUsernameMistake,
            ReplyTicket,
            SmsIsBlocked,
            NationalCodeInquiryUnSuccess,
            TheIdentityInquirySystemIsNotResponsive,
            IsNotResponsive
        };

        public static bool IsSuccess { get; set; }

        public static MessageType Error { get; set; }

        public static long Number { get; set; }

        public static string Text { get; set; }

        #endregion Properties

        #region Methods

        public static string GetMessage(MessageType error = MessageType.SuccessInsert, long? number = null, string text = "")
        {
            Error = error;
            Text = text;
            if (number != null)
            {
                Number = number.Value;
            }

            string Temp = string.Empty;

            switch (Error)
            {
                case MessageType.IsNotResponsive: Temp = "سامانه مورد نظر در حال حاضر پاسخگو نیست لطفا دقایقی دیگر مجدد تلاش کنید"; break;
                case MessageType.TheIdentityInquirySystemIsNotResponsive: Temp = "سامانه استعلام هویت پاسخگو نیست لطفا دقایفی دیگر مجدد تلاش کنید"; break;
                case MessageType.NationalCodeInquiryUnSuccess: Temp = "کد ملی ارسالی با کد ملی مالک شماره موبایل ثبت نامی تطابق ندارد"; break;
                case MessageType.SmsIsBlocked: Temp = "کلیه سرویس های پیام کوتاه به لطف وزارت ارتباطات تا اطلاع ثانوی در سراسر کشور قطع می باشد !!!"; break;
                case MessageType.VerifyConfirmed: Temp = string.Format(" {0} شما تایید شد ", Text); break;
                case MessageType.ReplyTicket: Temp = string.Format("تیکت {0} پاسخ داده شد", Text); break;
                case MessageType.VerifyRejected: Temp = string.Format(" {0} شما رد شد ", Text); break;
                case MessageType.ErrorSameExist: Temp = string.Format("این {0} قبلا در سامانه ثبت شده است.", Text); break;
                case MessageType.SuccessSent: Temp = string.Format(" {0} با موفقیت ارسال شد", Text); break;
                case MessageType.ErrorNotFoundItem: Temp = string.Format(" هیچ {0} با این مشخصات یافت نشد", Text); break;
                case MessageType.SuccessRegister: Temp = "ثبت نام شما با موفقیت انجام شد."; break;
                case MessageType.ErrorRegister: Temp = "ثبت نام شما با خطا همرا بود."; break;
                case MessageType.SuccessInsert: Temp = "اطلاعات با موفقیت ثبت شد."; break;
                case MessageType.SuccessUpdate: Temp = "اطلاعات با موفقیت ویرایش شد."; break;
                case MessageType.SuccessDelete: Temp = "اطلاعات با موفقیت حذف شد."; break;
                case MessageType.ErrorFailedCount: Temp = string.Format(" به دلیل درخواست های مکرر حساب شما به مدت {0} {1} مسدود شد", Number, Text); break;
                case MessageType.ErrorUserInActive: Temp = "حساب کاربری شما غیرفعال است"; break;
                case MessageType.ErrorInValidate: Temp = string.Format(" {0} وارد شده صحیح نیست", Text); break;
                case MessageType.ErrorUnSecurePassword: Temp = "رمز عبور شما ایمنی لازم را ندارد :"; break;
                case MessageType.SuccessAccept: Temp = string.Format(" {0} با موفقیت تایید شد", Text); break;
                case MessageType.ErrorLogin: Temp = "نام کاربری یا رمز عبور اشتباه است"; break;
                case MessageType.ErrorLoginAccessFailed: Temp = string.Format(" نام کاربری یا رمز عبور اشتباه است ، تعداد دفعات باقی مانده: {0} ", number); break;
                case MessageType.SuccessCall: Temp = "تا چند لحظه دیگر جهت تایید شماره با شما تماس میگیریم"; break;
                case MessageType.SuccessUpload: Temp = "فایل ارسالی با موفقیت دریافت شد"; break;
                case MessageType.SuccessUploadAuthenticationFile: Temp = "اطلاعات احراز هویت شما با موفقیت دریافت شد"; break;
                case MessageType.AllFieldsRequired: Temp = "پر کردن تمامی فیلد ها الزامی است."; break;
                case MessageType.StarFieldsRequired: Temp = "پر کردن فیلد های ستاره دار الزامی است."; break;
                case MessageType.PassNotEqualToRepass: Temp = "کلمه عبور و تکرار کلمه عبور یکسان نیست."; break;

                case MessageType.NotAccessAdmin: Temp = "کاربر محترم ، شما دسترسی لازم جهت انجام این عملیات را ندارید"; break;
                case MessageType.NotAccessUser: Temp = "کاربر محترم ، شما دسترسی لازم جهت انجام این عملیات را ندارید"; break;
                case MessageType.ErrorInSystem: Temp = "مشکلی در سیستم رخ داده است."; break;

                case MessageType.ErrorInInsert: Temp = "مشکلی در سیستم ثبت رخ داده است."; break;
                case MessageType.ErrorInUpdate: Temp = "مشکلی در سیستم ویرایش رخ داده است."; break;
                case MessageType.ErrorInDelete: Temp = "مشکلی در سیستم حذف رخ داده است."; break;
                case MessageType.ErrorInDeleteOrSet: Temp = "مشکلی در سیستم حذف/ست رخ داده است."; break;
                case MessageType.ErrorInDeleteOrUpdate: Temp = "مشکلی در سیستم حذف/ویرایش رخ داده است."; break;
                case MessageType.ErrorInInsertOrUpdate: Temp = "مشکلی در سیستم ثبت/ویرایش رخ داده است."; break;
                case MessageType.ErrorInInputParameter: Temp = "پارامترهای ورودی نادرست است. ، لطفا از دست کاری آدرس بپرهیزید"; break;
                case MessageType.ErrorInTypingData: Temp = "مقدار وارد شده نادرست است."; break;
                case MessageType.ErrorInValidInputData: Temp = "مقدار وارد شده غیر مجاز است."; break;
                case MessageType.ErrorTypingDataIsOutOfRanges: Temp = "مقدار وارد شده بیش از حد مجاز است."; break;
                case MessageType.ErrorInImageResizer: Temp = "مشکلی در سیستم ریسایزر رخ داده است."; break;
                case MessageType.ErrorInMailSender: Temp = "مشکلی در سیستم ارسال ایمیل رخ داده است."; break;
                case MessageType.ErrorInGettingData: Temp = "مشکلی در دریافت اطلاعات رخ داده است"; break;
                case MessageType.ErrorChoosePic: Temp = "انتخاب تصویر الزامی است."; break;
                case MessageType.ErrorChooseVideo: Temp = "انتخاب فیلم الزامی است."; break;
                case MessageType.ErrorChooseDoc: Temp = "انتخاب فایل متنی الزامی است."; break;
                case MessageType.ErrorChooseZip: Temp = "انتخاب فایل فشرده الزامی است."; break;
                case MessageType.ErrorInvalidAnimatedPicExt: Temp = string.Format("فرمت فایل تصویر غیرمجاز است.(فرمت های مجاز: {0})", ValidAnimatedPicExt); break;
                case MessageType.ErrorInvalidPicExt: Temp = string.Format("فرمت فایل تصویر غیرمجاز است. (فرمت های مجاز: {0})", ValidPicExt); break;
                case MessageType.ErrorInvalidDocExt: Temp = string.Format("فرمت فایل متنی غیرمجاز است. (فرمت های مجاز: {0})", ValidDocExt); break;
                case MessageType.ErrorInvalidZipExt: Temp = string.Format("فرمت فایل فشرده غیرمجاز است. (فرمت های مجاز: {0})", ValidZipExt); break;
                case MessageType.ErrorInvalidFileExt: Temp = string.Format("فرمت فایل غیرمجاز است. (فرمت های مجاز: {0})", ValidFileExt); break;
                case MessageType.ErrorInvalidFile: Temp = "فرمت فایل غیرمجاز است.)"; break;
                case MessageType.ErrorInvalidVideoExt: Temp = string.Format("فرمت ویدئو غیرمجاز است. (فرمت های مجاز: {0})", ValidVideoExt); break;
                case MessageType.ErrorInPicLen: Temp = "حجم تصویر بیش از حد مجاز است."; break;
                case MessageType.ErrorInVideoLen: Temp = "حجم فیلم بیش از حد مجاز است."; break;
                case MessageType.ErrorInFileLen: Temp = "حجم فایل بیش از حد مجاز است."; break;
                case MessageType.ErrorOutputIsEmpty: Temp = "موردی یافت نشد."; break;
                case MessageType.ErrorInSearch: Temp = "مشکلی در سیستم جستجو رخ داده است."; break;
                case MessageType.NewsLetterSended: Temp = string.Format("تعداد {0} خبرنامه ارسال گردید.", number); break;
                case MessageType.SuccessRefresh: Temp = "بروز رسانی با موفقیت انجام شد"; break;
                case MessageType.ErrorInRefresh: Temp = "مشکلی در سیستم بروزرسانی رخ داد ه است."; break;

                case MessageType.SuccessDecline: Temp = "اطلاعات با موفقیت رد شد."; break;
                case MessageType.SuccessPending: Temp = "اطلاعات با موفقیت در انتظار تایید شد."; break;
                case MessageType.ErrorInputOneTBox: Temp = "حداقل باید یکی از فیلدها را پر نمایید."; break;
                case MessageType.ErrorHaveChild: Temp = "این گزینه دارای زیر مجموعه می باشد ، لذا حذف آن میسر نیست."; break;
                case MessageType.ErrorOldPassword: Temp = "رمز عبور قبلی اشتباه است."; break;
                case MessageType.ErrorCantDelete: Temp = "این شخص قابل حذف نمی باشد."; break;
                case MessageType.ErrorDeleteSubset: Temp = "این شخص زیرمجموعه دارد و سیستم قادر به حذف نیست."; break;
                case MessageType.ErrorDeleteOrActive: Temp = "شما مجاز به حذف این شخص نیستید این شخص فعال می باشد و فقط مدیر سیستم مجاز به حذف می باشد."; break;
                case MessageType.SuccessSetGalleryCover: Temp = "کاور گالری با موفقیت تنظیم شد."; break;
                case MessageType.ErrorUsernameMistake: Temp = "نام کاربری یا کلمه عبور اشتباه است."; break;
                case MessageType.ErrorInRss:
                    break;
                case MessageType.ErrorNoCity:
                    break;
                case MessageType.ErrorNoCountry:
                    break;
                case MessageType.ErrorEmptyBasket:
                    break;
                case MessageType.ErrorNotAcceptPayToGetCard:
                    break;
                case MessageType.ErrorEndCapacity:
                    break;
                case MessageType.ErrorCityHaveMember:
                    break;
                default:
                    Temp = "پیام مورد نظر یافت نشد!";
                    break;
            }

            return Temp;
        }

        #endregion Methods
    }
}