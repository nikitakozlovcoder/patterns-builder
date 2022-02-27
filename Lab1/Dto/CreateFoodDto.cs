using Lab1.Constants;

namespace Lab1.Dto;

public class CreateFoodDto<T>
{
    public T? Payload { get; set; }
}